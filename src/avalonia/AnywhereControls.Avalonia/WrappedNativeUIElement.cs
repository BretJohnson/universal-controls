using Avalonia.Controls;

namespace AnywhereControls.Avalonia
{
    /// <summary>
    /// This class is for UI controls passed in from the host, for native WPF controls (not
    /// Standard UI built in controls or WpfStandardControl controls), which we wrap with an IUIElement here.
    /// </summary>
    public class WrappedNativeUIElement : IUIElement
    {
        private readonly Control _control;

        public WrappedNativeUIElement(Control control)
        {
            _control = control;
        }

        public Control Control => _control;

        void IUIElement.Measure(Size availableSize)
        {
            _control.Measure(availableSize.ToAvaloniaSize());
        }

        void IUIElement.Arrange(Rect finalRect)
        {
            _control.Arrange(finalRect.ToAvaloniaRect());
        }

        Size IUIElement.DesiredSize => _control.DesiredSize.ToAnywhereControlsSize();

        double IUIElement.ActualX => throw new NotImplementedException();

        double IUIElement.ActualY => throw new NotImplementedException();

        Thickness IUIElement.Margin
        {
            get => _control.Margin.ToAnywhereControlsThickness();
            set => _control.Margin = value.ToAvaloniaThickness();
        }

        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => _control.HorizontalAlignment.ToAnywhereControlsHorizontalAlignment();
            set => _control.HorizontalAlignment = value.ToAvaloniaHorizontalAlignment();
        }

        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => _control.VerticalAlignment.ToAnywhereControlsVerticalAlignment();
            set => _control.VerticalAlignment = value.ToAvaloniaVerticalAlignment();
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => _control.FlowDirection.ToStandardUIFlowDirection();
            set => _control.FlowDirection = value.ToAvaloniaFlowDirection();
        }

        // TODO: Error if appropriate when set to Visibility.Hidden
        bool IUIElement.Visible
        {
            get => _control.Visibility != System.Windows.Visibility.Collapsed;
            set => _control.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        double IUIElement.Width
        {
            get => _control.Width;
            set => _control.Width = value;
        }

        double IUIElement.MinWidth
        {
            get => _control.MinWidth;
            set => _control.MinWidth = value;
        }

        double IUIElement.MaxWidth
        {
            get => _control.MaxWidth;
            set => _control.MaxWidth = value;
        }

        double IUIElement.Height
        {
            get => _control.Height;
            set => _control.Height = value;
        }

        double IUIElement.MinHeight
        {
            get => _control.MinHeight;
            set => _control.MinHeight = value;
        }

        double IUIElement.MaxHeight
        {
            get => _control.MaxHeight;
            set => _control.MaxHeight = value;
        }

        double IUIElement.ActualWidth => _control.ActualWidth;

        double IUIElement.ActualHeight => _control.ActualHeight;

        object? IUIObject.GetValue(IUIProperty property) => _control.GetValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => _control.SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => _control.ClearValue(((UIProperty)property).DependencyProperty);

        int IUIElement.VisualChildrenCount => 0;

        public Rect Frame => throw new NotImplementedException();

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");
    }
}
