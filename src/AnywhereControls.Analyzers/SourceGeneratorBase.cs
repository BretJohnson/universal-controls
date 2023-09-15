using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.SourceGenerator
{
    /// <summary>
    /// Generates framework-specific implementations of StandardUI control interfaces. The
    /// consuming app specifies the control interfaces that it consumes via StandardUIControl
    /// assembly attributes.
    /// </summary>
    /// <example>
    /// [assembly: StandardUIControl("Namespace.IControlName")]
    /// </example>
    internal abstract class SourceGeneratorBase<TGenerateInput> : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext initializationContext)
        {
            // Enable this to be able to debug the source generators
#if false
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();
#endif

            IncrementalValuesProvider<TGenerateInput> syntaxProvider = initializationContext.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => Filter(node),
                    transform: (generatorSyntaxContext, _) => Transform(generatorSyntaxContext.SemanticModel, generatorSyntaxContext.Node))
                .Where(static transformResult => transformResult is not null)!;

            IncrementalValueProvider<(Compilation, ImmutableArray<TGenerateInput>)> generateInputProvider
                = initializationContext.CompilationProvider.Combine(syntaxProvider.Collect());

            initializationContext.RegisterSourceOutput(generateInputProvider,
                (sourceProductioContext, source) => GenerateAction(source.Item1, source.Item2, sourceProductioContext));
        }

        protected abstract bool Filter(SyntaxNode node);

        protected abstract TGenerateInput? Transform(SemanticModel semanticModel, SyntaxNode node);

        protected abstract void Generate(Context context, ImmutableArray<TGenerateInput> generateInput);

        private void GenerateAction(Compilation compilation, ImmutableArray<TGenerateInput> generateInput, SourceProductionContext sourceProductionContext)
        {
            try
            {
                if (generateInput.IsDefaultOrEmpty)
                    return;

                Context context = new Context(compilation, new GeneratorExecutionOutput(sourceProductionContext));
                Generate(context, generateInput);
            }
            catch (UserViewableException e)
            {
                var diagnosticDescriptor = new DiagnosticDescriptor(e.Id, "Anywhere Controls source generation failed",
                    e.Message, Utils.AnywhereControlsRootNamespace, DiagnosticSeverity.Error, isEnabledByDefault: true);
                sourceProductionContext.ReportDiagnostic(Diagnostic.Create(diagnosticDescriptor, e.Location));
            }
            catch (Exception e)
            {
                var diagnosticDescriptor = new DiagnosticDescriptor(UserVisibleErrors.InternalErrorId, "Anywhere Controls source generation failed with internal error",
                    e.ToString(), Utils.AnywhereControlsRootNamespace, DiagnosticSeverity.Error, isEnabledByDefault: true);
                sourceProductionContext.ReportDiagnostic(Diagnostic.Create(diagnosticDescriptor, null));
            }
        }

        public static string? GetAttributeFullTypeName(SemanticModel semanticModel, AttributeSyntax attributeSyntax)
        {
            if (semanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                return null;

            INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
            return attributeContainingTypeSymbol.ToDisplayString();
        }

        public static bool IsMatchingAttribute(SemanticModel semanticModel, AttributeSyntax attributeSyntax, string matchingAttributeTypeName1)
        {
            var thisAttributeTypeName = GetAttributeFullTypeName(semanticModel, attributeSyntax);
            if (thisAttributeTypeName == null)
                return false;

            return thisAttributeTypeName == matchingAttributeTypeName1;
        }

        public static bool IsMatchingAttribute(SemanticModel semanticModel, AttributeSyntax attributeSyntax, params string[] matchingAttributeTypeNames)
        {
            var thisAttributeTypeName = GetAttributeFullTypeName(semanticModel, attributeSyntax);
            if (thisAttributeTypeName == null)
                return false;

            foreach (string matchingAttributeTypeName in matchingAttributeTypeNames)
            {
                if (thisAttributeTypeName == matchingAttributeTypeName)
                    return true;
            }

            return false;
        }

        public static AttributeSyntax? GetTypeAttribute(SemanticModel semanticModel, TypeDeclarationSyntax typeDeclarationSyntax, string matchingAttributeTypeName)
        {
            foreach (AttributeListSyntax attributeListSyntax in typeDeclarationSyntax.AttributeLists)
            {
                foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
                {
                    if (IsMatchingAttribute(semanticModel, attributeSyntax, matchingAttributeTypeName))
                        return attributeSyntax;
                }
            }

            return null;
        }

        public static AttributeSyntax? GetTypeAttribute(SemanticModel semanticModel, TypeDeclarationSyntax typeDeclarationSyntax, params string[] matchingAttributeTypeNames)
        {
            foreach (AttributeListSyntax attributeListSyntax in typeDeclarationSyntax.AttributeLists)
            {
                foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
                {
                    if (IsMatchingAttribute(semanticModel, attributeSyntax, matchingAttributeTypeNames))
                        return attributeSyntax;
                }
            }

            return null;
        }

        public static INamedTypeSymbol? GetAttributeTypeArgument(SemanticModel semanticModel, AttributeSyntax attributeSyntax, int argIndex)
        {
            ExpressionSyntax? attributeArg = attributeSyntax.ArgumentList!.Arguments[argIndex].Expression;
            if (attributeArg is not TypeOfExpressionSyntax typeOfExpressionSyntax)
                return null;

            TypeSyntax? typeArgument = typeOfExpressionSyntax.Type;
            return semanticModel.GetSymbolInfo(typeArgument).Symbol as INamedTypeSymbol;
        }

        public static string? GetAttributeStringArgument(AttributeSyntax attributeSyntax, int argIndex)
        {
            ExpressionSyntax? attributeArg = attributeSyntax.ArgumentList!.Arguments[argIndex].Expression;
            if (attributeArg is not LiteralExpressionSyntax literalExpressionSyntax)
                return null;

            if (literalExpressionSyntax.Kind() != SyntaxKind.StringLiteralExpression)
                return null;

            SyntaxToken token = literalExpressionSyntax.Token;
            if (token.Value is not string stringValue)
                return null;

            return stringValue;
        }

        public static INamedTypeSymbol? GetAttributedType(SemanticModel semanticModel, AttributeSyntax attributeSyntax)
        {
            SyntaxNode? attributedTypeSyntax = attributeSyntax.Parent;
            if (attributedTypeSyntax == null)
                return null;

            SymbolInfo symbolInfo = semanticModel.GetSymbolInfo(attributedTypeSyntax);
            return symbolInfo.Symbol as INamedTypeSymbol;
        }

        public static AttributeSyntax? GetAttribute(SemanticModel semanticModel, SyntaxList<AttributeListSyntax> attributeListsSyntax, string attributeTypeName)
        {
            foreach (AttributeListSyntax attributeListSyntax in attributeListsSyntax)
            {
                foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
                {
                    string? currentAttributeTypeName = GetAttributeFullTypeName(semanticModel, attributeSyntax);
                    if (currentAttributeTypeName == attributeTypeName)
                        return attributeSyntax;
                }
            }

            return null;
        }

        /// <summary>
        /// Return the namespace for a given type, by inspecting the syntax tree. This can
        /// be used when the semantic model (symbols) isn't available.
        /// </summary>
        /// <param name="typeDeclationSyntax">type syntax node</param>
        /// <returns>namespace for that type or the empty string if there's no namespace</returns>
        public static string GetNamespace(BaseTypeDeclarationSyntax typeDeclationSyntax)
        {
            string typeNamespace = string.Empty;

            // Search up the syntax tree for a namespace declaration
            SyntaxNode? potentialNamespaceParent = typeDeclationSyntax.Parent;
            while (potentialNamespaceParent != null &&
                    potentialNamespaceParent is not NamespaceDeclarationSyntax &&
                    potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax)
            {
                potentialNamespaceParent = potentialNamespaceParent.Parent;
            }

            if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
            {
                typeNamespace = namespaceParent.Name.ToString();

                // Search up the tree again for outer namespace declarations that enclose
                // this one, adding each that we find as a prefix
                while (true)
                {
                    if (namespaceParent.Parent is not NamespaceDeclarationSyntax parent)
                        break;

                    typeNamespace = $"{namespaceParent.Name}.{typeNamespace}";
                    namespaceParent = parent;
                }
            }

            return typeNamespace;
        }

        public static UIFramework GetUIFramework(Context context)
        {
            foreach (AssemblyIdentity referencedAssembly in context.Compilation.ReferencedAssemblyNames)
            {
                string assemblyName = referencedAssembly.Name;

                if (assemblyName == "AnywhereControls.Wpf")
                    return new WpfUIFramework(context);
                else if (assemblyName == "AnywhereControls.WinForms")
                    return new WinFormsUIFramework(context);
                else if (assemblyName == "AnywhereControls.Blazor")
                    return new BlazorUIFramework(context);
                else if (assemblyName == "AnywhereControls.Maui")
                    return new MauiUIFramework(context);
            }

            throw UserVisibleErrors.CouldNotIdentifyUIFramework();
        }
    }
}
