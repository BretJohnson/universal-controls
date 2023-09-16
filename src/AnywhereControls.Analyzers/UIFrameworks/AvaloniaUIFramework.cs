namespace AnywhereControls.SourceGenerator.UIFrameworks
{
    public class AvaloniaUIFramework : XamlUIFramework
    {
        public AvaloniaUIFramework(Context context) : base(context)
        {
        }

        public override string Name => "Avalonia";
        public override TypeName DependencyPropertyType => new("Avalolnia", "StyledProperty");
        public override TypeName ContentPropertyAttribute => new("Avalonia.Metadata", "ContentAttribute");

        public override string FrameworkTypeForUIElementAttachedTarget => "Avalonia.Control";
        public override string ToFrameworkTypeForUIElementAttachedTarget => "ToAvaloniaUIElement";

        public override string NativeUIElementType => "Avalonia.Control";
        public override string WrapperSuffix => "Avalonia";
        protected override string FontFamilyDefaultValue => "global::Avalonia.Media.FontFamily.Default.Name";

        public override void GenerateStandardPanelLayoutMethods(string layoutManagerTypeName, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine($"protected override global::Avalonia.Size MeasureOverride(global::Avalonia.Size availableSize) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();");
            }

            methods.AddBlankLine();
            methods.AddLine($"protected override global::Avalonia.Size ArrangeOverride(global::Avalonia.Size finalSize) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();");
            }
        }

        public override void GeneratePanelMethods(Source methods)
        {
            methods.AddBlankLineIfNonempty();

            methods.AddLine(
                "protected override int VisualChildrenCount => _children.Count;");
            methods.AddBlankLine();
            methods.AddLine(
                "protected override System.Windows.Media.Visual GetVisualChild(int index) => (System.Windows.Media.Visual) _children[index];");
        }

        public override void GenerateDrawableObjectMethods(Interface intface, Source methods)
        {
            base.GenerateDrawableObjectMethods(intface, methods);

            if (intface.IsThisType(KnownTypes.ITextBlock))
            {
                methods.AddLine(
                    $"protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>");
                using (methods.Indent())
                {
                    methods.AddLine(
                        $"HostEnvironment.VisualFramework.MeasureTextBlock(this).ToWpfSize();");
                }
            }
        }

        public override void GenerateIUIElementMethods(ClassSource classSource)
        {
            Source methods = classSource.NonstaticMethods;

            classSource.Usings.AddTypeAlias("Visibility = System.Windows.Visibility");

            // TODO: Error if appropriate when set to Visibility.Hidden

            methods.AddLines(
                "void IUIElement.Measure(double widthConstraint, double heightConstraint) =>",
                "    Measure(new System.Windows.Size(widthConstraint, heightConstraint));",
                "void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());",
                "Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();",
                "",
                "double IUIElement.ActualX => throw new System.NotImplementedException();",
                "double IUIElement.ActualY => throw new System.NotImplementedException();",
                "");
            methods.AddProperty("Thickness IUIElement.Margin", "Margin.ToStandardUIThickness()", "Margin = value.ToWpfThickness()");
            methods.AddBlankLine();
            methods.AddProperty("HorizontalAlignment IUIElement.HorizontalAlignment", "HorizontalAlignment.ToStandardUIHorizontalAlignment()", "HorizontalAlignment = value.ToWpfHorizontalAlignment()");
            methods.AddBlankLine();
            methods.AddProperty("VerticalAlignment IUIElement.VerticalAlignment", "VerticalAlignment.ToAnywhereControlsVerticalAlignment()", "VerticalAlignment = value.ToWpfVerticalAlignment()");
            methods.AddBlankLine();
            methods.AddProperty("FlowDirection IUIElement.FlowDirection", "FlowDirection.ToStandardUIFlowDirection()", "FlowDirection = value.ToWpfFlowDirection()");
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
                "object? IUIObject.ReadLocalValue(IUIProperty property) => ReadLocalValue(((UIProperty)property).DependencyProperty);",
                "void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);",
                "void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);");
            methods.AddBlankLine();
            methods.AddLines(
                "protected override int VisualChildrenCount =>",
                "    ((IUIElement)this).VisualChildrenCount;");
            methods.AddLines(
                "protected override System.Windows.Media.Visual GetVisualChild(int index) =>",
                "    ((IUIElement)this).GetVisualChild(index).ToWpfUIElement();");
        }
    }
}
