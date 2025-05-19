namespace AnywhereUI.SourceGenerator.UIFrameworks
{
    public class WpfUIFramework : XamlUIFramework
    {
        public WpfUIFramework(Context context) : base(context)
        {
        }

        public override string Name => "Wpf";
        public override TypeName DependencyPropertyType => new("System.Windows", "DependencyProperty");
        public override TypeName ContentPropertyAttribute => new("System.Windows.Markup", "ContentPropertyAttribute");

        public override string FrameworkTypeForUIElementAttachedTarget => "System.Windows.UIElement";
        public override string ToFrameworkTypeForUIElementAttachedTarget => "ToWpfUIElement";

        public override string NativeUIElementType => "System.Windows.FrameworkElement";
        public override string WrapperSuffix => "Wpf";
        protected override string FontFamilyDefaultValue => "AnywhereUI.Wpf.Text.FontFamilyExtensions.DefaultFontFamily";


        public override void GenerateStandardPanelLayoutMethods(string layoutManagerTypeName, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine($"protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToWpfSize();");
            }

            methods.AddBlankLine();
            methods.AddLine($"protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToWpfSize();");
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

        public override void GenerateDrawableObjectMethods(UIObjectType uiObjectType, Source methods)
        {
            base.GenerateDrawableObjectMethods(uiObjectType, methods);

            if (uiObjectType.IsThisType(KnownTypes.ITextBlock))
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

        public override void GenerateBuiltInIUIElementPartialClasses()
        {
            GenerateBuiltInIUIElementPartialClass(new TypeName(RootNamespace, "BuiltInUIElement"));
            GenerateBuiltInIUIElementPartialClass(new TypeName("AnywhereUI.Controls", "HostFrameworkAnywhereControl"));
        }

        private void GenerateBuiltInIUIElementPartialClass(TypeName typeName)
        {
            var classSource = new ClassSource(Context,
                namespaceName: typeName.Namespace,
                isPartial: true,
                className: typeName.Name,
                fileNameOverride: typeName.Name + "Generated");

            GenerateIUIElementMethods(classSource);
            classSource.AddToOutput(this);
        }

        public override void GenerateIUIElementMethods(ClassSource classSource)
        {
            Source methods = classSource.NonstaticMethods;

            classSource.Usings.AddTypeAlias("Visibility = System.Windows.Visibility");
            classSource.Usings.AddNamespace("AnywhereUI.Wpf");

            // TODO: Error if appropriate when set to Visibility.Hidden

            methods.Add("""
                void IUIElement.Measure(Size availableSize) => Measure(availableSize.ToWpfSize());
                void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());
                Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();
                
                double IUIElement.ActualX => throw new NotImplementedException();
                double IUIElement.ActualY => throw new NotImplementedException();
                """);

            methods.AddProperty("Thickness IUIElement.Margin", "Margin.ToAnywhereControlsThickness()", "Margin = value.ToWpfThickness()");
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
            methods.Add("""
                double IUIElement.ActualWidth => ActualWidth;
                double IUIElement.ActualHeight => ActualHeight;
                
                object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
                void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
                void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);
                """);
            methods.AddBlankLine();
            methods.Add("""
                protected override int VisualChildrenCount =>
                    ((IUIElement)this).VisualChildrenCount;
                """);
            methods.Add("""
                protected override System.Windows.Media.Visual GetVisualChild(int index) =>
                    ((IUIElement)this).GetVisualChild(index).ToWpfUIElement();
                """);

            GenerateEventHandlersStoreSupport(classSource);

            classSource.Usings.AddNamespace("System.Windows.Input");
            classSource.Usings.AddNamespace("AnywhereUI.Input");
            classSource.Usings.AddNamespace("AnywhereUI.Wpf.Input");

            GenerateHostFrameworkMappedEvent(classSource, eventName: "PointerEntered", handlerType: "PointerEventHandler",
                hostFrameworkEvent: "MouseEnter", hostFrameworkEventArgsType: "MouseEventArgs", mappedEventArgsType: "MousePointerEventArgs");
            GenerateHostFrameworkMappedEvent(classSource, eventName: "PointerExited", handlerType: "PointerEventHandler",
                hostFrameworkEvent: "MouseLeave", hostFrameworkEventArgsType: "MouseEventArgs", mappedEventArgsType: "MousePointerEventArgs");
            GenerateHostFrameworkMappedEvent(classSource, eventName: "PointerMoved", handlerType: "PointerEventHandler",
                hostFrameworkEvent: "MouseMove", hostFrameworkEventArgsType: "MouseEventArgs", mappedEventArgsType: "MousePointerEventArgs");
        }
    }
}
