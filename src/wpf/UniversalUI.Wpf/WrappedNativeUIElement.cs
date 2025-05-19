using System;
using AnywhereUI.Input;
using FrameworkElement = System.Windows.FrameworkElement;

namespace AnywhereUI.Wpf
{
    /// <summary>
    /// This class is for UI controls passed in from the host, for native WPF controls (not
    /// Standard UI built in controls or WpfStandardControl controls), which we wrap with an IUIElement here.
    /// </summary>
    public class WrappedNativeUIElement : IUIElement
    {
        private readonly FrameworkElement _frameworkElement;

        public WrappedNativeUIElement(FrameworkElement frameworkElement)
        {
            _frameworkElement = frameworkElement;
        }

        public FrameworkElement FrameworkElement => _frameworkElement;

        void IUIElement.Measure(Size availableSize) => _frameworkElement.Measure(availableSize.ToWpfSize());

        void IUIElement.Arrange(Rect finalRect) => _frameworkElement.Arrange(finalRect.ToWpfRect());

        Size IUIElement.DesiredSize => _frameworkElement.DesiredSize.ToAnywhereControlsSize();

        double IUIElement.ActualX => throw new NotImplementedException();

        double IUIElement.ActualY => throw new NotImplementedException();

        Thickness IUIElement.Margin
        {
            get => _frameworkElement.Margin.ToAnywhereControlsThickness();
            set => _frameworkElement.Margin = value.ToWpfThickness();
        }

        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => _frameworkElement.HorizontalAlignment.ToStandardUIHorizontalAlignment();
            set => _frameworkElement.HorizontalAlignment = value.ToWpfHorizontalAlignment();
        }

        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => _frameworkElement.VerticalAlignment.ToAnywhereControlsVerticalAlignment();
            set => _frameworkElement.VerticalAlignment = value.ToWpfVerticalAlignment();
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => _frameworkElement.FlowDirection.ToStandardUIFlowDirection();
            set => _frameworkElement.FlowDirection = value.ToWpfFlowDirection();
        }

        // TODO: Error if appropriate when set to Visibility.Hidden
        bool IUIElement.Visible
        {
            get => _frameworkElement.Visibility != System.Windows.Visibility.Collapsed;
            set => _frameworkElement.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        double IUIElement.Width
        {
            get => _frameworkElement.Width;
            set => _frameworkElement.Width = value;
        }

        double IUIElement.MinWidth
        {
            get => _frameworkElement.MinWidth;
            set => _frameworkElement.MinWidth = value;
        }

        double IUIElement.MaxWidth
        {
            get => _frameworkElement.MaxWidth;
            set => _frameworkElement.MaxWidth = value;
        }

        double IUIElement.Height
        {
            get => _frameworkElement.Height;
            set => _frameworkElement.Height = value;
        }

        double IUIElement.MinHeight
        {
            get => _frameworkElement.MinHeight;
            set => _frameworkElement.MinHeight = value;
        }

        double IUIElement.MaxHeight
        {
            get => _frameworkElement.MaxHeight;
            set => _frameworkElement.MaxHeight = value;
        }

        double IUIElement.ActualWidth => _frameworkElement.ActualWidth;

        double IUIElement.ActualHeight => _frameworkElement.ActualHeight;

        object? IUIObject.GetValue(IUIProperty property) => _frameworkElement.GetValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => _frameworkElement.SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => _frameworkElement.ClearValue(((UIProperty)property).DependencyProperty);

        int IUIElement.VisualChildrenCount => 0;

        public Rect Frame => throw new NotImplementedException();

        Rect IUIElement.Frame => throw new NotImplementedException();

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");

        event PointerEventHandler IUIElement.PointerEntered
        {
            add { throw EventsHandlersNotSupportedException(); }
            remove { throw EventsHandlersNotSupportedException(); }
        }

        event PointerEventHandler IUIElement.PointerExited
        {
            add { throw EventsHandlersNotSupportedException(); }
            remove { throw EventsHandlersNotSupportedException(); }
        }

        event PointerEventHandler IUIElement.PointerMoved
        {
            add { throw EventsHandlersNotSupportedException(); }
            remove { throw EventsHandlersNotSupportedException(); }
        }

        public NotSupportedException EventsHandlersNotSupportedException() =>
            new NotSupportedException("Adding event handers to host framework UI elements isn't currently suuported. Wrap it with an AnywhereControls control instead to get events.");
    }
}
