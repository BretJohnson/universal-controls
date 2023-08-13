using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
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
    [Generator]
    internal class ControlLibraryGenerator : SourceGeneratorBase<SyntaxNode>
    {
        protected override bool Filter(SyntaxNode node) =>
            node is InterfaceDeclarationSyntax interfaceDeclarationSyntax && interfaceDeclarationSyntax.AttributeLists.Count > 0 ||
            node is ClassDeclarationSyntax classDeclarationSyntax && classDeclarationSyntax.AttributeLists.Count > 0;

        protected override SyntaxNode? Transform(SemanticModel semanticModel, SyntaxNode node)
        {
            if (node is InterfaceDeclarationSyntax interfaceDeclarationSyntax &&
                GetTypeAttribute(semanticModel, interfaceDeclarationSyntax, KnownTypes.StandardControlAttribute,
                    KnownTypes.StandardUIElementAttribute, KnownTypes.StandardUISingletonAttribute) != null)
            {
                return interfaceDeclarationSyntax;
            }
            else if (node is ClassDeclarationSyntax classDeclarationSyntax &&
                GetTypeAttribute(semanticModel, classDeclarationSyntax, KnownTypes.ControlLibraryAttribute) != null)
            {
                return classDeclarationSyntax;
            }

            return null;
        }

        protected override void Generate(Context context, ImmutableArray<SyntaxNode> inputs)
        {
            INamedTypeSymbol? controlLibraryClass = null;
            List<Interface> interfaces = new();

            foreach (SyntaxNode input in inputs)
            {
                if (input is InterfaceDeclarationSyntax interfaceDeclarationSyntax)
                {
                    SemanticModel semanticModel = context.Compilation.GetSemanticModel(interfaceDeclarationSyntax.SyntaxTree);
                    ISymbol? symbol = semanticModel.GetDeclaredSymbol(interfaceDeclarationSyntax);
                    if (symbol is INamedTypeSymbol interfaceTypeSymbol)
                    {
                        var intface = new Interface(context, interfaceTypeSymbol);
                        interfaces.Add(intface);
                    }
                }
                else if (input is ClassDeclarationSyntax classDeclarationSyntax)
                {
                    SemanticModel semanticModel = context.Compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
                    ISymbol? symbol = semanticModel.GetDeclaredSymbol(classDeclarationSyntax);
                    if (symbol is INamedTypeSymbol classTypeSymbol)
                    {
                        controlLibraryClass = classTypeSymbol;
                    }
                }
            }

            if (controlLibraryClass == null)
                return;

            var controlLibrary = new ControlLibrary(context, controlLibraryClass, interfaces);
            controlLibrary.GenerateStaticsClass();
            controlLibrary.GenerateFactoryClass();
            controlLibrary.GenerateExtensionsClasses();
        }
    }
}
