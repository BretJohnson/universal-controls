namespace AnywhereControls.SourceGenerator.UIFrameworks
{
    public abstract class NonXamlUIFramework : UIFramework
    {
        protected NonXamlUIFramework(Context context) : base(context)
        {
        }

        public virtual void GeneratePropertyAttribute(Property property, Source source) {}

        public override void GenerateProperty(Property property, ClassSource classSource)
        {
            classSource.Usings.AddNamespace("AnywhereControls.DefaultImplementations");

            // Add the property descriptor
            string readOnlyParam = property.IsReadOnly ? ", readOnly:true" : "";
            classSource.StaticFields.AddLine(
                $"public static readonly UIProperty {PropertyDescriptorName(property)} = new UIProperty(nameof({property.Name}), {DefaultValue(property)}{readOnlyParam});");

            if (property.IsUICollection)
            {
                string fieldName = PropertyFieldName(property);
                string fieldTypeName = PropertyOutputTypeName(property);

                classSource.NonstaticFields.AddLine(
                    $"private {fieldTypeName} {fieldName};");

                classSource.DefaultConstructorBody.AddLines(
                    $"{fieldName} = new {fieldTypeName}(this);",
                    $"SetValue({PropertyDescriptorName(property)}, {fieldName});");
            }

            GeneratePropertyMethods(property, classSource.NonstaticMethods);
        }

        protected string GetValueExpression(Property property)
        {
            string propertyOutputTypeName = PropertyOutputTypeName(property);
            string descriptorName = PropertyDescriptorName(property);

            if (property.IsNonNullable())
                return $"({propertyOutputTypeName}) GetNonNullValue({descriptorName})";
            else
                return $"({propertyOutputTypeName}) GetValue({descriptorName})";
        }

        private void GeneratePropertyMethods(Property property, Source source)
        {
            var usings = source.Usings;
            string propertyOutputTypeName = PropertyOutputTypeName(property);
            string getValueMethod = property.IsNonNullable() ? "GetNonNullValue" : "GetValue";

            // Add the type - for interface type and the framework type (if different)
            usings.AddTypeNamespace(property.Type);
            if (IsWrappedType(property.Type) || Utils.IsUIModelInterfaceType(property.Type))
                usings.AddNamespace(ToFrameworkNamespaceName(property.Type.ContainingNamespace));

            AddTypeAliasUsingIfNeeded(usings, propertyOutputTypeName);

#if LATER
            SyntaxTokenList modifiers;
            if (includeXmlComment)
                modifiers = TokenList(
                    Token(
                        TriviaList(xmlCommentTrivia),
                        SyntaxKind.PublicKeyword,
                        TriviaList()));
            else
                modifiers = TokenList(Token(SyntaxKind.PublicKeyword));
#endif

            source.AddBlankLineIfNonempty();
            string descriptorName = PropertyDescriptorName(property);

            string getterValue;
            string setterAssignment;
            if (IsWrappedType(property.Type))
            {
                getterValue = $"({propertyOutputTypeName}) {getValueMethod}({descriptorName}).{property.TypeName}";
                setterAssignment = $"SetValue({descriptorName}, new {propertyOutputTypeName}(value)";
            }
            else if (Utils.IsUICollectionType(Context, property.Type, out var elementType) && propertyOutputTypeName.StartsWith("UIElementCollection<"))
            {
                getterValue = $"{PropertyFieldName(property)}.ToStandardUIElementCollection()";
                setterAssignment = ""; // Not used
            }
            else
            {
                getterValue = $"({propertyOutputTypeName}) {getValueMethod}({descriptorName})";
                setterAssignment = $"SetValue({descriptorName}, value)";
            }

            GeneratePropertyAttribute(property, source);
            if (property.IsReadOnly)
            {
                source.AddLine(
                    $"public {property.TypeName} {property.Name} => {getterValue};");
            }
            else
            {
                source.AddLines(
                    $"public {property.TypeName} {property.Name}",
                    "{");
                using (source.Indent())
                {
                    source.AddLines(
                        $"get => {getterValue};",
                        $"set => {setterAssignment};"
                    );
                }
                source.AddLine(
                    "}");
            }
        }

        public override void GenerateAttachedProperty(AttachedProperty attachedProperty, ClassSource mainClassSource, ClassSource attachedClassSource)
        {
            // Add using for AttachedUIProperty
            mainClassSource.Usings.AddNamespace("AnywhereControls.DefaultImplementations");

            string descriptorName = PropertyDescriptorName(attachedProperty);
            string targetOutputTypeName = AttachedTargetOutputTypeName(attachedProperty);
            string propertyOutputTypeName = PropertyOutputTypeName(attachedProperty);

            string readOnlyParam = attachedProperty.IsReadOnly ? ", readOnly:true" : "";
            mainClassSource.StaticFields.AddLine(
                $"public static readonly AttachedUIProperty {PropertyDescriptorName(attachedProperty)} = new AttachedUIProperty(\"{attachedProperty.Name}\", {DefaultValue(attachedProperty)}{readOnlyParam});");

            mainClassSource.StaticMethods.AddBlankLineIfNonempty();
            mainClassSource.StaticMethods.AddLine($"public static {propertyOutputTypeName} Get{attachedProperty.Name}({targetOutputTypeName} {attachedProperty.TargetParameterName}) => ({propertyOutputTypeName}) AttachedPropertiesValues.GetValue({attachedProperty.TargetParameterName}, {descriptorName});");
            if (attachedProperty.SetterMethod != null)
                mainClassSource.StaticMethods.AddLine($"public static void Set{attachedProperty.Name}({targetOutputTypeName} {attachedProperty.TargetParameterName}, {propertyOutputTypeName} value) => AttachedPropertiesValues.SetValue({attachedProperty.TargetParameterName}, {descriptorName}, value);");

            attachedClassSource.NonstaticMethods.AddBlankLineIfNonempty();
            attachedClassSource.NonstaticMethods.AddLine($"public {propertyOutputTypeName} Get{attachedProperty.Name}({attachedProperty.TargetTypeName} {attachedProperty.TargetParameterName}) => {attachedProperty.Interface.FrameworkClassName}.Get{attachedProperty.Name}(({targetOutputTypeName}) {attachedProperty.TargetParameterName});");
            if (attachedProperty.SetterMethod != null)
                attachedClassSource.NonstaticMethods.AddLine($"public void Set{attachedProperty.Name}({attachedProperty.TargetTypeName} {attachedProperty.TargetParameterName}, {propertyOutputTypeName} value) => {attachedProperty.Interface.FrameworkClassName}.Set{attachedProperty.Name}(({targetOutputTypeName}) {attachedProperty.TargetParameterName}, value);");
        }
    }
}
