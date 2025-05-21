using System.Linq;
using Microsoft.CodeAnalysis;

namespace UniversalUI.SourceGenerator
{
    public class AttachedProperty : PropertyBase
    {
        public INamedTypeSymbol AttachedType { get; }
        public IMethodSymbol GetterMethod { get; }
        public IMethodSymbol? SetterMethod { get; }
        public ITypeSymbol TargetType { get; }
        public string TargetTypeName { get; }
        public string? TargetParameterName { get; }

        public AttachedProperty(Context context, UIObjectType uiObjectType, INamedTypeSymbol attachedType, IMethodSymbol getterMethod, IMethodSymbol? setterMethod) :
            base(context, uiObjectType, getterMethod, getterMethod.Name.Substring("Get".Length), getterMethod.ReturnType, setterMethod == null, attachedType.Name)
        {
            if (getterMethod.Parameters.Length != 1)
                throw new UserViewableException(
                        $"Attached type getter method {attachedType.Name}.{getterMethod.Name} doesn't take a single parameter");
            IParameterSymbol targetParameter = getterMethod.Parameters.First();

            AttachedType = attachedType;
            GetterMethod = getterMethod;
            SetterMethod = setterMethod;
            TargetType = targetParameter.Type;
            TargetTypeName = Utils.ToTypeName(TargetType);
            TargetParameterName = targetParameter.Name;
            SpecifiedDefaultValue = GetSpecifiedDefaultValue(getterMethod);

            if (setterMethod != null && setterMethod.Parameters.Length != 2)
            {
                throw new UserViewableException(
                    $"Attached type setter method {attachedType.Name}.{setterMethod.Name} doesn't take two parameters as expected");
            }
        }

        public override string ToString() => Name;

        public void GenerateExtensionClassMethods(Source source)
        {
            source.Usings.AddTypeNamespace(Type);
            source.Usings.AddTypeNamespace(TargetType);

            // Get the type base name, without the "I" nor "Attached" suffix
            string typeBaseName = UIObjectType.BaseName;

            string targetVariableName = Utils.GeTypeVariableName(TargetType);

            source.AddBlankLineIfNonempty();
            source.AddLines(
                $"public static {TypeName} {typeBaseName}{Name}<T>(this T uiElement) where T : {TargetTypeName} => {typeBaseName}AttachedInstance.Get{Name}(uiElement);");
            if (!IsReadOnly)
            {
                source.AddLines(
                    $"public static T {typeBaseName}{Name}<T>(this T {targetVariableName}, {TypeName} value) where T : {TargetTypeName}",
                    "{");
                using (source.Indent())
                {
                    source.AddLines(
                        $"{typeBaseName}AttachedInstance.Set{Name}({targetVariableName}, value);",
                        $"return {targetVariableName};");
                }
                source.AddLine(
                    "}");
            }
        }
    }
}
