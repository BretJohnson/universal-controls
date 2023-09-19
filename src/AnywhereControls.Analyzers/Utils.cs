using System;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.SourceGenerator
{
    public static class Utils
    {
        public const string AnywhereControlsRootNamespace = "AnywhereControls";

        public static readonly SymbolDisplayFormat TypeFullNameSymbolDisplayFormat =
            new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        public static string ToTypeName(ITypeSymbol type) =>
            AddNullableSuffixIfNeeded(ToTypeNameNonNullable(type), type.NullableAnnotation);

        public static string AddNullableSuffixIfNeeded(string typeName, NullableAnnotation nullableAnnotation) =>
            nullableAnnotation == NullableAnnotation.Annotated ? typeName + "?" : typeName;

        public static string ToTypeNameNonNullable(ITypeSymbol type)
        {
            string? builtInTypeName = GetBuiltInTypeName(type);
            if (builtInTypeName != null)
                return builtInTypeName;

            string typeName = type.Name;
            if (typeName.Length == 0)
                throw new UserViewableException($"Type {type} has no type name");

            if (type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var buffer = new StringBuilder(typeName);
                buffer.Append("<");

                bool firstArgument = true;
                foreach (ITypeSymbol typeArgument in namedType.TypeArguments)
                {
                    if (!firstArgument)
                        buffer.Append(",");
                    buffer.Append(typeArgument.Name);

                    firstArgument = false;
                }

                buffer.Append(">");
                return buffer.ToString();
            }

            return typeName;
        }

        public static string? GetBuiltInTypeName(ITypeSymbol type)
        {
            switch (type.SpecialType)
            {
                case SpecialType.System_Boolean:
                    return "bool";
                case SpecialType.System_SByte:
                    return "sbyte";
                case SpecialType.System_Int16:
                    return "short";
                case SpecialType.System_Int32:
                    return "int";
                case SpecialType.System_Int64:
                    return "long";
                case SpecialType.System_Byte:
                    return "byte";
                case SpecialType.System_UInt16:
                    return "ushort";
                case SpecialType.System_UInt32:
                    return "uint";
                case SpecialType.System_UInt64:
                    return "ulong";
                case SpecialType.System_Single:
                    return "ulong";
                case SpecialType.System_Double:
                    return "double";
                case SpecialType.System_Char:
                    return "char";
                case SpecialType.System_Object:
                    return "object";
                case SpecialType.System_String:
                    return "string";
                default:
                    return null;
            }
        }

        public static string ToNonnullableType(string type)
        {
            if (type.EndsWith("?"))
                return type.Substring(0, type.Length - 1);
            else return type;
        }

        /// <summary>
        /// Convert the type name, normally starting with an upper case character, to a variable name,
        /// lowercasing the initial character(s) per convention.
        /// 
        /// element => element
        /// Element => element
        /// AElement => aElement
        /// UIElement => uiElement
        /// </summary>
        public static string PascalCaseToCamelCase(string typeName)
        {
            int upperCasePrefixCharCount = 0;
            int length = typeName.Length;
            for (int i = 0; i < length; ++i)
            {
                if (char.IsUpper(typeName[i]))
                    ++upperCasePrefixCharCount;
                else break;
            }

            if (upperCasePrefixCharCount == 0)
                return typeName;
            else if (upperCasePrefixCharCount == 1)
                return typeName.Substring(0, 1).ToLower() + typeName.Substring(1);
            else
                return typeName.Substring(0, upperCasePrefixCharCount - 1).ToLower() + typeName.Substring(upperCasePrefixCharCount - 1);
        }

        public static string GetInterfaceVariableName(ITypeSymbol typeSymbol)
        {
            var name = typeSymbol.Name;
            if (!name.StartsWith("I"))
            {
                throw new InvalidOperationException($"Type name {name}, which should be an interface, unexpectedly doesn't start with an 'I'");
            }

            // e.g. ICanvas => canvas, IUIElement => uiElement
            return PascalCaseToCamelCase(name.Substring(1));
        }

        public static bool IsTransformType(TypeSyntax type)
        {
            if (type is NullableTypeSyntax nullableType)
                type = nullableType.ElementType;

            return type is IdentifierNameSyntax identifierName && identifierName.Identifier.Text.EndsWith("Transform");
        }

        public static bool IsThisType(ITypeSymbol type, string typeFullName) => GetTypeFullName(type) == typeFullName;

        public static bool IsSubtypeOf(INamedTypeSymbol type, string potentialAncestorType)
        {
            if (type.TypeKind != TypeKind.Interface)
                throw new InvalidOperationException($"Currently IsSubtypeOf can only be called on interface types, not type {type} of kind {type.TypeKind}");

            foreach (INamedTypeSymbol intface in type.Interfaces)
            {
                if (IsThisType(intface, potentialAncestorType) || IsSubtypeOf(intface, potentialAncestorType))
                    return true;
            }

            return false;
        }

        public static bool IsSubtypeOf(ITypeSymbol type, string potentialAncestorType)
        {
            if (type is not INamedTypeSymbol namedTypeSymbol)
                return false;

            return IsSubtypeOf(namedTypeSymbol, potentialAncestorType);
        }

        public static string GetTypeFullName(ITypeSymbol type) => type.ToDisplayString(TypeFullNameSymbolDisplayFormat);

        public static string GetTypeNamespace(ITypeSymbol type) => type.ToDisplayString(TypeFullNameSymbolDisplayFormat);

        public static string GetNamespaceFullName(INamespaceSymbol namespce) => namespce.ToDisplayString(TypeFullNameSymbolDisplayFormat);

        /// <summary>
        /// Return true if the namespace is under the specified prefix (e.g. "AnywhereControls.Shapes" is
        /// under "AnywhereControls"). Also returns true if the namespace is the prefix itself
        /// (e.g. "AnywhereControls" is under "AnywhereControls").
        /// </summary>
        /// <param name="namespaceName">namespace in question</param>
        /// <param name="prefixNamespaceName">potential namespace prefix</param>
        /// <returns>whether prefixNamespaceName is under (or the same as) namespaceName</returns>
        public static bool IsNamespaceUnder(string namespaceName, string prefixNamespaceName) => namespaceName.StartsWith(prefixNamespaceName + ".") || namespaceName == prefixNamespaceName;

        public static bool IncludeDraw(ITypeSymbol type)
        {
            if (type is not INamedTypeSymbol namedType)
                return false;

            if (IsThisType(type, KnownTypes.ITextBlock))
                return true;

            foreach (INamedTypeSymbol intface in namedType.Interfaces)
            {
                if (IsThisType(intface, KnownTypes.IShape))
                    return true;
            }

            return false;
        }

        public static bool IsUIModelInterfaceType(ITypeSymbol type)
        {
            return type.TypeKind == TypeKind.Interface && type.Name != "IEnumerable";  // TODO: Use attribute check instead
        }

        public static bool IsUICollectionType(Context context, ITypeSymbol type, out ITypeSymbol elementType)
        {
            elementType = context.VoidType;

            if (!IsThisType(type, KnownTypes.IUICollection))
                return false;

            if (type is not INamedTypeSymbol namedTypeSymbol)
                return false;

            ImmutableArray<ITypeSymbol> typeArguments = namedTypeSymbol.TypeArguments;
            if (typeArguments.Length != 1)
                return false;

            elementType = typeArguments[0];
            return true;
        }

        public static bool IsUICollectionType(Context context, ITypeSymbol type) => IsUICollectionType(context, type, out ITypeSymbol _);

        /// <summary>
        /// Return the child namespace (e.g. "Shapes", "Transforms", etc.) or null if there is no child
        /// and classes should be at the root.
        /// </summary>
        /// <param name="sourceNamespace">source namespace</param>
        /// <returns>child namespace</returns>
        public static string? GetChildNamespaceName(string namespaceName, UIFramework? uiFramework = null)
        {
            string rootNamespace;
            if (uiFramework != null && namespaceName.StartsWith(uiFramework.RootNamespace))
                rootNamespace = uiFramework.RootNamespace;
            else rootNamespace = AnywhereControlsRootNamespace;

            if (namespaceName == rootNamespace)
                return null;

            string prefix = rootNamespace + ".";
            if (namespaceName.StartsWith(prefix))
                return namespaceName.Substring(prefix.Length);
            else throw new InvalidOperationException($"namespace {namespaceName} doesn't start with '{rootNamespace}' as expected");
        }

        /// <summary>
        /// Get the value (the single constructor argument) for the specified attribute or null if the
        /// attribute isn't present. If the attribute has multiple constructor arguments, that's
        /// treated as an error.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="attributeTypeName"></param>
        /// <returns></returns>
        /// <exception cref="UserViewableException"></exception>
        public static TypedConstant? GetAttributeValue(ISymbol symbol, string attributeTypeName)
        {
            ImmutableArray<AttributeData> attributes = symbol.GetAttributes();
            foreach (AttributeData attribute in attributes)
            {
                var attributeTypeFullName = Utils.GetTypeFullName(attribute.AttributeClass!);
                if (attributeTypeFullName != attributeTypeName)
                    continue;

                ImmutableArray<TypedConstant> constructorArguments = attribute.ConstructorArguments;
                if (constructorArguments.Length != 1)
                    throw UserVisibleErrors.AttributeShouldHaveSingleArgument(symbol, GetAttributeName(attributeTypeName));

                return constructorArguments[0];
            }

            return null;
        }

        public static string? GetAttributeStringValue(ISymbol symbol, string attributeTypeName)
        {
            object? value = Utils.GetAttributeValue(symbol, attributeTypeName)?.Value;
            if (value == null)
                return null;

            if (value is not string stringValue)
                throw UserVisibleErrors.AttributeShouldHaveAStringArgument(symbol, GetAttributeName(attributeTypeName));

            return stringValue;
        }

        public static string GetAttributeName(string attributeTypeName)
        {
            string attributeName = attributeTypeName;

            int lastPeriodIndex = attributeName.LastIndexOf('.');
            if (lastPeriodIndex != -1)
                attributeName = attributeName.Substring(lastPeriodIndex + 1);

            if (attributeName.EndsWith("Attribute"))
                attributeName = attributeName.Substring(0, attributeName.Length - "Attribute".Length);

            return attributeName;
        }
    }
}
