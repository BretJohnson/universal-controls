namespace AnywhereUI.SourceGenerator.UIFrameworks
{
    public class AvaloniaUIFramework : XamlUIFramework
    {
        public AvaloniaUIFramework(Context context) : base(context)
        {
        }

        public override bool UseNewNamingConvention => true;
        public override string Name => "Avalonia";
        public override TypeName DependencyPropertyType => new("Avalolnia.Media", "StyledProperty");
        public override TypeName ContentPropertyAttribute => new("Avalonia.Metadata", "ContentAttribute");
        public override ContentPropertyStyle ContentPropertyStyle => ContentPropertyStyle.PropertyAttribute;

        public override string FrameworkTypeForUIElementAttachedTarget => "Avalonia.Controls.Control";
        public override string ToFrameworkTypeForUIElementAttachedTarget => "ToAvaloniaControl";

        public override string NativeUIElementType => "Avalonia.Controls.Control";
        public override string WrapperSuffix => "Avalonia";
        protected override string FontFamilyDefaultValue => "AnywhereControlsAvalonia.Text.FontFamilyExtensions.DefaultFontFamily";

        protected override void GeneratePropertyDescriptor(Property property, ClassSource classSource)
        {
            classSource.Usings.AddTypeAlias("AvaloniaProperty = Avalonia.AvaloniaProperty");

            string propertyType = PropertyOutputTypeName(property);

            classSource.StaticFields.AddLine(
                $"public static readonly Avalonia.StyledProperty<{propertyType}> {PropertyDescriptorName(property)} = " +
                $"AvaloniaProperty.Register<{property.UIObjectType.FrameworkClassName}, {propertyType}>(nameof({property.Name}), {DefaultValue(property)});");
        }

        protected override void GenerateAttachedPropertyDescriptor(AttachedProperty attachedProperty, ClassSource mainClassSource, ClassSource attachedClassSource)
        {
            mainClassSource.Usings.AddTypeAlias("AvaloniaProperty = Avalonia.AvaloniaProperty");

            string propertyType = PropertyOutputTypeName(attachedProperty);
            string targetOutputTypeName = AttachedTargetOutputTypeName(attachedProperty);

            mainClassSource.StaticFields.AddLine(
                $"public static readonly Avalonia.AttachedProperty<{propertyType}> {PropertyDescriptorName(attachedProperty)} = " +
                $"AvaloniaProperty.RegisterAttached<{attachedProperty.UIObjectType.FrameworkClassName}, {targetOutputTypeName}, {propertyType}>(\"{attachedProperty.Name}\", {DefaultValue(attachedProperty)});");
        }

        public override void GenerateStandardPanelLayoutMethods(string layoutManagerTypeName, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine($"protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();");
            }

            methods.AddBlankLine();
            methods.AddLine($"protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();");
            }
        }

        public override void GeneratePanelMethods(Source methods)
        {
            methods.AddBlankLineIfNonempty();

            methods.AddLine("#if LATER");
            methods.AddLine(
                "protected override int VisualChildrenCount => _children.Count;");
            methods.AddBlankLine();
            methods.AddLine(
                "protected override System.Windows.Media.Visual GetVisualChild(int index) => (System.Windows.Media.Visual) _children[index];");
            methods.AddLine(
                "#endif");
        }

        public override void GenerateDrawableObjectMethods(UIObjectType uiObjectType, Source methods)
        {
            base.GenerateDrawableObjectMethods(uiObjectType, methods);

            if (uiObjectType.IsThisType(KnownTypes.ITextBlock))
            {
                methods.AddLine(
                    $"protected override Avalonia.Size MeasureOverride(Avalonia.Size constraint) =>");
                using (methods.Indent())
                {
                    methods.AddLine(
                        $"HostEnvironment.VisualFramework.MeasureTextBlock(this).ToAvaloniaSize();");
                }
            }
        }

        public override void GenerateIUIElementMethods(ClassSource classSource)
        {
            Source methods = classSource.NonstaticMethods;

            classSource.Usings.AddTypeAlias("Visibility = System.Windows.Visibility");

            // TODO: Error if appropriate when set to Visibility.Hidden

            methods.AddLines(
                "void IUIElement.Measure(Size availableSize) =>",
                "    Measure(new System.Windows.Size(widthConstraint, heightConstraint));",
                "void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToAvaloniaRect());",
                "Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();",
                "",
                "double IUIElement.ActualX => throw new System.NotImplementedException();",
                "double IUIElement.ActualY => throw new System.NotImplementedException();",
                "");
            methods.AddProperty("Thickness IUIElement.Margin", "Margin.ToAnywhereUIThickness()", "Margin = value.ToAvaloniaThickness()");
            methods.AddBlankLine();
            methods.AddProperty("HorizontalAlignment IUIElement.HorizontalAlignment", "HorizontalAlignment.ToAnywhereUIHorizontalAlignment()", "HorizontalAlignment = value.ToAvaloniaHorizontalAlignment()");
            methods.AddBlankLine();
            methods.AddProperty("VerticalAlignment IUIElement.VerticalAlignment", "VerticalAlignment.ToAnywhereControlsVerticalAlignment()", "VerticalAlignment = value.ToAvaloniaVerticalAlignment()");
            methods.AddBlankLine();
            methods.AddProperty("FlowDirection IUIElement.FlowDirection", "FlowDirection.ToAnywhereUIFlowDirection()", "FlowDirection = value.ToAvaloniaFlowDirection()");
            methods.AddBlankLine();
            methods.AddProperty("bool IUIElement.Visible", "Visibility != Visibility.Collapsed", "Visibility = value ? Visibility.Visible : Visibility.Collapsed");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.Width", "Width", "Width = value");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.MinWidth", "MinWidth", "MinWidth = value");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.MaxWidth", "MaxWidth", "MaxWidth = value");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.Height", "Height", "Height = value");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.MinHeight", "MinHeight", "MinHeight = value");
            methods.AddBlankLine();
            methods.AddProperty("double IUIElement.MaxHeight", "MaxHeight", "MaxHeight = value");
            methods.AddBlankLine();
            methods.AddLines(
                "double IUIElement.ActualWidth => ActualWidth;",
                "double IUIElement.ActualHeight => ActualHeight;",
                "",
                "object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);",
                "void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);",
                "void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);");
            methods.AddBlankLine();
            methods.AddLines(
                "protected override int VisualChildrenCount =>",
                "    ((IUIElement)this).VisualChildrenCount;");
            methods.AddLines(
                "protected override System.Windows.Media.Visual GetVisualChild(int index) =>",
                "    ((IUIElement)this).GetVisualChild(index).ToAvaloniaUIElement();");
        }
    }
}
