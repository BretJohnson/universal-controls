// This file is generated. Update the source to change its contents.

using Visibility = System.Windows.Visibility;

namespace Microsoft.StandardUI.Wpf
{
    public partial class BuiltInUIElement
    {
        void IUIElement.Measure(double widthConstraint, double heightConstraint) =>
            Measure(new System.Windows.Size(widthConstraint, heightConstraint));
        void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());
        Size IUIElement.DesiredSize => DesiredSize.ToStandardUISize();
        
        double IUIElement.ActualX => throw new System.NotImplementedException();
        double IUIElement.ActualY => throw new System.NotImplementedException();
        
        Thickness IUIElement.Margin
        {
            get => Margin.ToStandardUIThickness();
            set => Margin = value.ToWpfThickness();
        }
        
        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => HorizontalAlignment.ToStandardUIHorizontalAlignment();
            set => HorizontalAlignment = value.ToWpfHorizontalAlignment();
        }
        
        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => VerticalAlignment.ToStandardUIVerticalAlignment();
            set => VerticalAlignment = value.ToWpfVerticalAlignment();
        }
        
        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToWpfFlowDirection();
        }
        
        bool IUIElement.Visible
        {
            get => Visibility != Visibility.Collapsed;
            set => Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        
        double IUIElement.Width
        {
            get => Width;
            set => Width = value;
        }
        
        double IUIElement.MinWidth
        {
            get => MinWidth;
            set => MinWidth = value;
        }
        
        double IUIElement.MaxWidth
        {
            get => MaxWidth;
            set => MaxWidth = value;
        }
        
        double IUIElement.Height
        {
            get => Height;
            set => Height = value;
        }
        
        double IUIElement.MinHeight
        {
            get => MinHeight;
            set => MinHeight = value;
        }
        
        double IUIElement.MaxHeight
        {
            get => MaxHeight;
            set => MaxHeight = value;
        }
        
        double IUIElement.ActualWidth => ActualWidth;
        double IUIElement.ActualHeight => ActualHeight;
        
        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
        object? IUIObject.ReadLocalValue(IUIProperty property) => ReadLocalValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);
        
        protected override int VisualChildrenCount =>
            ((IUIElement)this).VisualChildrenCount;
        protected override System.Windows.Media.Visual GetVisualChild(int index) =>
            ((IUIElement)this).GetVisualChild(index).ToWpfUIElement();
    }
}
