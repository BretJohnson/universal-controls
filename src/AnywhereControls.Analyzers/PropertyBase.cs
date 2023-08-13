using Microsoft.CodeAnalysis;

namespace Microsoft.StandardUI.SourceGenerator
{
    public class PropertyBase
    {
        public Context Context { get; }
        public Interface Interface { get; }
        public ISymbol Symbol { get; }
        public string Name { get; }
        public ITypeSymbol Type { get; }
        public bool IsReadOnly { get; }
        public ITypeSymbol? UICollectionElementType { get; }
        public TypedConstant? SpecifiedDefaultValue { get; protected set; }
        public string FullPropertyName { get; }

        public PropertyBase(Context context, Interface intface, ISymbol symbol, string name, ITypeSymbol type, bool isReadOnly, string containingTypeName)
        {
            Context = context;
            Interface = intface;
            Symbol = symbol;
            Name = name;
            Type = type;
            IsReadOnly = isReadOnly;
            FullPropertyName = $"{containingTypeName}.{name}";

            if (Utils.IsUICollectionType(context, Type, out ITypeSymbol uiCollectionElementType))
                UICollectionElementType = uiCollectionElementType;
            else UICollectionElementType = null;
        }

        public string TypeName => Utils.ToTypeName(Type);
        public bool IsUICollection => UICollectionElementType != null;
        public string UICollectionElementTypeName => Utils.ToTypeName(UICollectionElementType!);

        public TypedConstant? GetSpecifiedDefaultValue(ISymbol symbol) => Utils.GetAttributeValue(symbol, KnownTypes.DefaultValueAttribute);

        public bool IsNonNullable()
        {
            NullableAnnotation nullableAnnotation = Type.NullableAnnotation;

            if (nullableAnnotation == NullableAnnotation.Annotated)
                return false;
            else if (nullableAnnotation == NullableAnnotation.NotAnnotated)
                return true;
            else
            {
                TypeKind kind = Type.TypeKind;
                return kind == TypeKind.Enum || kind == TypeKind.Struct;
            }
        }
    }
}
