using System;
using System.Windows.Media;
using Visibility = System.Windows.Visibility;

namespace AnywhereControls.Wpf
{
    /// <summary>
    /// This is the base for predefined UI elements.
    /// </summary>
    public class BuiltInUIElement : System.Windows.FrameworkElement, IUIElement, ILogicalParent
    {
        private StandardUIFrameworkElementHelper _helper = new();

        protected override void OnRender(DrawingContext drawingContextWpf)
        {
            base.OnRender(drawingContextWpf);

            if (Visibility != System.Windows.Visibility.Visible)
                return;

            if (this is not IDrawable drawable)
                return;

            IVisualFramework visualFramework = HostEnvironment.VisualFramework;

            using (IDrawingContext drawingContext = visualFramework.CreateDrawingContext(this))
            {
                drawable.Draw(drawingContext);
                IVisual? visual = drawingContext.Close();

                if (visual != null)
                {
                    _helper.OnRender(visual, Width, Height, drawingContextWpf);
                }
            }
        }

        protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            InvalidateVisual();
        }

        public Rect Frame => throw new NotImplementedException();

        void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);
        void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);

        int IUIElement.VisualChildrenCount => 0;

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");

        void IUIElement.Measure(Size availableSize) => Measure(availableSize.ToWpfSize());
        void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());
        Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

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
