using Microsoft.CodeAnalysis;

namespace UniversalUI.SourceGenerator
{
    public class Property : PropertyBase
    {
        public IPropertySymbol PropertySymbol { get; }

        public Property(Context context, UIObjectType uiObjectType, IPropertySymbol propertySymbol) :
            base(context, uiObjectType, propertySymbol, propertySymbol.Name, propertySymbol.Type, propertySymbol.IsReadOnly, uiObjectType.Name)
        {
            PropertySymbol = propertySymbol;
            SpecifiedDefaultValue = GetSpecifiedDefaultValue(propertySymbol);
        }

        public override string ToString() => Name;

        public void GenerateExtensionClassMethods(Source source)
        {
            if (IsReadOnly && !IsUICollection)
                return;

            source.Usings.AddTypeNamespace(Type);

            string interfaceVariableName = UIObjectType.VariableName;

            source.AddBlankLineIfNonempty();
            if (IsUICollection)
            {
                source.AddLines(
                    $"public static T {Name}<T>(this T {interfaceVariableName}, params {UICollectionElementTypeName}[] value) where T : {UIObjectType.Name}",
                    "{");
                using (source.Indent())
                {
                    source.AddLines(
                        $"{interfaceVariableName}.{Name}.Set(value);",
                        $"return {interfaceVariableName};");
                }
                source.AddLine(
                    "}");
            }
            else
            {
                source.AddLines(
                    $"public static T {Name}<T>(this T {interfaceVariableName}, {TypeName} value) where T : {UIObjectType.Name}",
                    "{");
                using (source.Indent())
                {
                    source.AddLines(
                        $"{interfaceVariableName}.{Name} = value;",
                        $"return {interfaceVariableName};");
                }
                source.AddLine(
                    "}");
            }
        }
    }
}
