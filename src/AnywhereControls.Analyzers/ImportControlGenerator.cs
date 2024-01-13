using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.SourceGenerator
{
    /// <summary>
    /// Generates framework-specific implementations of Anywhere Controls control interfaces. The
    /// consuming app specifies the control interfaces that it consumes via StandardUIControl
    /// assembly attributes.
    /// </summary>
    /// <example>
    /// [assembly: StandardUIControl("Namespace.IControlName")]
    /// </example>
    [Generator]
    internal class ImportControlGenerator : SourceGeneratorBase<AttributeSyntax>
    {
        protected override bool Filter(SyntaxNode node) =>
            node is AttributeSyntax attrib && attrib.ArgumentList?.Arguments.Count == 1;

        protected override AttributeSyntax? Transform(SemanticModel semanticModel, SyntaxNode node)
        {
            var attributeSyntax = (AttributeSyntax)node;

            string? fullName = GetAttributeFullTypeName(semanticModel, attributeSyntax);
            if (fullName != KnownTypes.ImportAnywhereControlAttribute)
                return null;

            return attributeSyntax;
        }

        protected override void Generate(Context context, ImmutableArray<AttributeSyntax> importAttributes)
        {
            HashSet<string> generatedInterfaces = new HashSet<string>();
            foreach (AttributeSyntax attributeSyntax in importAttributes)
            {
                SemanticModel semanticModel = context.Compilation.GetSemanticModel(attributeSyntax.SyntaxTree);
                INamedTypeSymbol? importType = GetAttributeTypeArgument(semanticModel, attributeSyntax, 0);
                if (importType == null)
                    continue;

                string fullTypeName = importType.ToString();
                if (generatedInterfaces.Contains(fullTypeName))
                    continue;

                GenerateSourceFile(context, importType);
                generatedInterfaces.Add(fullTypeName);

                // Generate any ancestor types
                INamedTypeSymbol? ancestorType = GetBaseInterface(importType);
                while (ancestorType != null)
                {
                    string ancestorFullTypeName = Utils.GetTypeFullName(ancestorType);

                    if (ancestorFullTypeName == KnownTypes.IAnywhereControl || generatedInterfaces.Contains(ancestorFullTypeName))
                        break;

                    GenerateSourceFile(context, ancestorType);
                    generatedInterfaces.Add(ancestorFullTypeName);

                    ancestorType = GetBaseInterface(ancestorType);
                }
            }
        }

        private static void GenerateSourceFile(Context context, INamedTypeSymbol interfaceSymbol)
        {
            UIFramework uiFramework = GetUIFramework(context);

            var uiObjectType = new UIObjectType(context, interfaceSymbol);
            uiObjectType.Generate(uiFramework);
        }

        /// <summary>
        /// Return the first base interface or null if there aren't any
        /// </summary>
        private static INamedTypeSymbol? GetBaseInterface(INamedTypeSymbol interfaceSymbol)
        {
            foreach (INamedTypeSymbol baseInterface in interfaceSymbol.Interfaces)
            {
                return baseInterface;
            }

            return null;
        }

        /// <summary>
        /// Given the full name (with namespace) of an interface type, extracts various other related strings.
        /// </summary>
        /// <param name="interfaceFullTypeName">The full name (with namespace) of an interface type. For example, Contoso.Controls.IControl</param>
        /// <param name="interfaceNamespace">The interface's namespace. For example, Contoso.Controls</param>
        /// <param name="controlTypeName">The default name of the class implementing the interface (by convention). For example, Control</param>
        /// <returns>True if the output strings were successfully determined, otherwise false.</returns>
        private static bool TryGetTypeNamesFromInterface(string interfaceFullTypeName, out string interfaceNamespace, out string controlTypeName)
        {
            int lastDotIndex = interfaceFullTypeName.LastIndexOf('.');
            if (lastDotIndex < 3)
            {
                interfaceNamespace = "";
                controlTypeName = "";
                return false;
            }

            controlTypeName = interfaceFullTypeName.Substring(lastDotIndex + 2);
            interfaceNamespace = interfaceFullTypeName.Substring(0, lastDotIndex);
            return true;
        }

    }
}
