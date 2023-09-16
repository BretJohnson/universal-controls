using Avalonia.Controls;
using Avalonia.Media;

namespace AnywhereControls.Avalonia
{
    /// <summary>
    /// This is the base for predefined UI elements.
    /// </summary>
    public class BuiltInUIElement : Control, IUIElement, ILogicalParent
    {
        private StandardUIFrameworkElementHelper _helper = new();

        public override void Render(DrawingContext drawingContextAvalonia)
        {
            base.Render(drawingContextAvalonia);

            if (! IsVisible)
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
                    _helper.OnRender(visual, Width, Height, drawingContextAvalonia);
                }
            }
        }

        // TODO: Handle if needed for Avalonia
#if false
        protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            InvalidateVisual();
        }
#endif

        public Rect Frame => throw new NotImplementedException();

        void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);
        void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);

        int IUIElement.VisualChildrenCount => 0;

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");

        void IUIElement.Measure(Size availableSize) => Measure(availableSize.ToAvaloniaSize());
        void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToAvaloniaRect());
        Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

        double IUIElement.ActualX => throw new System.NotImplementedException();
        double IUIElement.ActualY => throw new System.NotImplementedException();

        Thickness IUIElement.Margin
        {
            get => Margin.ToAnywhereControlsThickness();
            set => Margin = value.ToAvaloniaThickness();
        }

        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => HorizontalAlignment.ToAnywhereControlsHorizontalAlignment();
            set => HorizontalAlignment = value.ToAvaloniaHorizontalAlignment();
        }

        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => VerticalAlignment.ToAnywhereControlsVerticalAlignment();
            set => VerticalAlignment = value.ToAvaloniaVerticalAlignment();
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToAvaloniaFlowDirection();
        }

        bool IUIElement.Visible
        {
            get => IsVisible;
            set => IsVisible = value;
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

        double IUIElement.ActualWidth => Bounds.Width;
        double IUIElement.ActualHeight => Bounds.Height;

        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);

#if LATER
        protected override int VisualChildrenCount =>
            ((IUIElement)this).VisualChildrenCount;
        protected override global::Avalonia.Media.Visual GetVisualChild(int index) =>
            ((IUIElement)this).GetVisualChild(index).ToAvaloniaControl();
#endif
    }
}
