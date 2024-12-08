using System;
using AnywhereUI.Input;
using Microsoft.Maui.Controls;

namespace AnywhereUI.Maui
{
    public class BuiltInUIElementDrawable : Microsoft.Maui.Graphics.IDrawable
    {
        public Microsoft.Maui.Graphics.ICanvas? Canvas { get; set; }

        public void Draw(Microsoft.Maui.Graphics.ICanvas canvas, Microsoft.Maui.Graphics.RectF dirtyRect)
        {
            Canvas = canvas;
        }
    }

    /// <summary>
    /// This is the base for predefined Anywhere Controls controls. 
    /// </summary>
    public class BuiltInUIElement : GraphicsView, IUIElement
    {
        readonly BuiltInUIElementDrawable _drawable;

        public BuiltInUIElement()
        {
            Drawable = _drawable = new BuiltInUIElementDrawable();
        }

        event PointerEventHandler? IUIElement.PointerEntered
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PointerEventHandler? IUIElement.PointerExited
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PointerEventHandler? IUIElement.PointerMoved
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public BuiltInUIElementDrawable BuiltInUIElementDrawable => _drawable;

        void IUIElement.Measure(Size availableSize)
        {
            Microsoft.Maui.SizeRequest sizeRequest = Measure(availableSize.Width, availableSize.Height, MeasureFlags.None);

            HorizontalOptions = HorizontalOptions;
        }

        void IUIElement.Arrange(Rect finalRect)
        {
            Arrange(finalRect.ToMauiRect());
        }

        Size IUIElement.DesiredSize => SizeExtensions.ToAnywhereControlsSize(DesiredSize);

        double IUIElement.ActualX => X;

        double IUIElement.ActualY => Y;

        Thickness IUIElement.Margin
        {
            get => Margin.ToStandardUIThickness();
            set => Margin = value.ToMauiThickness();
        }

        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => HorizontalOptions.Alignment.ToStandardUIHorizontalAlignment();
            set => HorizontalOptions = new LayoutOptions(value.ToMauiLayoutAlignment(), HorizontalOptions.Expands);
        }

        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => VerticalOptions.Alignment.ToStandardUIVerticalAlignment();
            set => VerticalOptions = new LayoutOptions(value.ToMauiLayoutAlignment(), VerticalOptions.Expands);
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToMauiFlowDirection();
        }

        // TODO: Error if appropriate when set to Visibility.Hidden
        bool IUIElement.Visible
        {
            get => IsVisible;
            set => IsVisible = value;
        }

        double IUIElement.Width
        {
            get => WidthRequest;
            set => WidthRequest = value;
        }

        double IUIElement.MinWidth
        {
            get => MinimumWidthRequest;
            set => MinimumWidthRequest = value;
        }

        double IUIElement.MaxWidth
        {
            get => MaximumWidthRequest;
            set => MaximumWidthRequest = value;
        }

        double IUIElement.Height
        {
            get => HeightRequest;
            set => HeightRequest = value;
        }

        double IUIElement.MinHeight
        {
            get => MinimumHeightRequest;
            set => MinimumHeightRequest = value;
        }

        double IUIElement.MaxHeight
        {
            get => MaximumHeightRequest;
            set => MaximumHeightRequest = value;
        }

        double IUIElement.ActualWidth => Width;

        double IUIElement.ActualHeight => Height;

        Rect IUIElement.Frame => throw new NotImplementedException();

        public int VisualChildrenCount => throw new NotImplementedException();

        int IUIElement.VisualChildrenCount => throw new NotImplementedException();

#if TODO
        protected override void OnRender(DrawingContext drawingContextWpf)
        {
            base.OnRender(drawingContextWpf);

            if (Visibility != Visibility.Visible)
                return;

            IVisualFramework visualFramework = HostEnvironment.VisualFramework;

            Rect cullingRect = new Rect(0, 0, 200, 200);

            IVisual? visual;
            using (IDrawingContext drawingContext = visualFramework.CreateDrawingContext(this)) {
                Draw(drawingContext);
                visual = drawingContext.Close();
            }

            if (visual != null)
            {
                _helper.OnRender(visual, Width, Height, drawingContextWpf);
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            InvalidateVisual();
        }
#endif

        public virtual void Draw(IDrawingContext visualizer)
        {
        }

        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).BindableProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).BindableProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).BindableProperty);

        public IUIElement GetVisualChild(int index)
        {
            throw new NotImplementedException();
        }

        IUIElement IUIElement.GetVisualChild(int index)
        {
            throw new NotImplementedException();
        }

#if TODO
        void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);
        void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);
#endif
    }
}
