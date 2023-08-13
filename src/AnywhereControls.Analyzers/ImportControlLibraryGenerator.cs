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
    internal class ImportControlLibraryGenerator : SourceGeneratorBase<AttributeSyntax>
    {
        protected override bool Filter(SyntaxNode node) =>
            node is AttributeSyntax attrib && attrib.ArgumentList?.Arguments.Count == 1;

        protected override AttributeSyntax? Transform(SemanticModel semanticModel, SyntaxNode node)
        {
            var attributeSyntax = (AttributeSyntax)node;

            string? fullName = GetAttributeFullTypeName(semanticModel, attributeSyntax);
            if (fullName != KnownTypes.ImportControlLibraryAttribute)
                return null;

            return attributeSyntax;
        }

        protected override void Generate(Context context, ImmutableArray<AttributeSyntax> importAttributes)
        {
            HashSet<string> generatedControlLibraries = new HashSet<string>();
            foreach (AttributeSyntax attributeSyntax in importAttributes)
            {
                SemanticModel semanticModel = context.Compilation.GetSemanticModel(attributeSyntax.SyntaxTree);
                INamedTypeSymbol? controlLibraryType = GetAttributeTypeArgument(semanticModel, attributeSyntax, 0);
                if (controlLibraryType == null)
                    continue;

                string fullTypeName = controlLibraryType.ToString();
                if (generatedControlLibraries.Contains(fullTypeName))
                    continue;

                GenerateControlLibrary(context, controlLibraryType);
                generatedControlLibraries.Add(fullTypeName);
            }
        }

        private static void GenerateControlLibrary(Context context, INamedTypeSymbol controlLibraryType)
        {
            var controlLibrary = new ControlLibrary(context, controlLibraryType.ContainingAssembly);

            UIFramework uiFramework = GetUIFramework(context);
            controlLibrary.GenerateLibraryClass(uiFramework);
            controlLibrary.GenerateControlClasses(uiFramework);
        }
    }
}
