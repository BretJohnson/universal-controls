using Microsoft.CodeAnalysis;

namespace Microsoft.StandardUI.SourceGenerator
{
    public class Property : PropertyBase
    {
        public IPropertySymbol PropertySymbol { get; }

        public Property(Context context, Interface intface, IPropertySymbol propertySymbol) :
            base(context, intface, propertySymbol, propertySymbol.Name, propertySymbol.Type, propertySymbol.IsReadOnly, intface.Name)
        {
            PropertySymbol = propertySymbol;
            SpecifiedDefaultValue = GetSpecifiedDefaultValue(propertySymbol);
        }

        public void GenerateExtensionClassMethods(Source source)
        {
            if (IsReadOnly && !IsUICollection)
                return;

            source.Usings.AddTypeNamespace(Type);

            string interfaceVariableName = Interface.VariableName;

            source.AddBlankLineIfNonempty();
            if (IsUICollection)
            {
                source.AddLines(
                    $"public static T {Name}<T>(this T {interfaceVariableName}, params {UICollectionElementTypeName}[] value) where T : {Interface.Name}",
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
                    $"public static T {Name}<T>(this T {interfaceVariableName}, {TypeName} value) where T : {Interface.Name}",
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
