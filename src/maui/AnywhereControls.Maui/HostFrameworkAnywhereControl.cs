using Microsoft.Maui.Controls;
using AnywhereControls.Maui.NativeVisualFramework;
using System;
using AnywhereControls.Maui;

namespace AnywhereControls.Controls
{
    public class HostFrameworkAnywhereControlDrawable : Microsoft.Maui.Graphics.IDrawable
    {
        public Microsoft.Maui.Graphics.ICanvas? Canvas { get; set; }

        public void Draw(Microsoft.Maui.Graphics.ICanvas canvas, Microsoft.Maui.Graphics.RectF dirtyRect)
        {
            Canvas = canvas;
        }
    }

    public abstract class HostFrameworkAnywhereControl : GraphicsView, IAnywhereControl
    {
        readonly HostFrameworkAnywhereControlDrawable _drawable;
        protected IUIElement? _buildContent;
        bool _invalid = true;

        public HostFrameworkAnywhereControl()
        {
            Drawable = _drawable = new HostFrameworkAnywhereControlDrawable();

            if (!HostEnvironment.IsInitialized)
            {
                MauiHostFramework.Init(new MauiNativeVisualFramework(_drawable.Canvas!));
            }
        }

        public double MinWidth
        {
            get => MinimumWidthRequest;
            set => MinimumWidthRequest = value;
        }

        public double MaxWidth
        {
            get => MaximumWidthRequest;
            set => MaximumWidthRequest = value;
        }

        public double MinHeight
        {
            get => MinimumHeightRequest;
            set => MinimumHeightRequest = value;
        }

        public double MaxHeight
        {
            get => MaximumHeightRequest;
            set => MaximumHeightRequest = value;
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get => HorizontalOptions.Alignment.ToStandardUIHorizontalAlignment();
            set => HorizontalOptions = new LayoutOptions(value.ToMauiLayoutAlignment(), HorizontalOptions.Expands);
        }

        public VerticalAlignment VerticalAlignment
        {
            get => VerticalOptions.Alignment.ToStandardUIVerticalAlignment();
            set => VerticalOptions = new LayoutOptions(value.ToMauiLayoutAlignment(), VerticalOptions.Expands);
        }

        public double ActualX => X;

        public double ActualY => Y;

        public double ActualWidth => Width;

        public double ActualHeight => Height;

        public bool Visible
        {
            get => IsVisible;
            set => IsVisible = value;
        }

        public int VisualChildrenCount => _buildContent != null ? 1 : 0;

        double IUIElement.Width
        {
            get => WidthRequest;
            set => WidthRequest = value;
        }

        double IUIElement.Height
        {
            get => HeightRequest;
            set => HeightRequest = value;
        }

        Thickness IUIElement.Margin
        {
            get => Margin.ToStandardUIThickness();
            set => Margin = value.ToMauiThickness();
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToMauiFlowDirection();
        }

        Rect IUIElement.Frame => Frame.ToStandardUIRect();

        Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Rect bounds)
        {
            Arrange(bounds);

            return base.ArrangeOverride(bounds);
        }

        public void Arrange(Rect finalRect)
        {
            ((IUIElement)this).Arrange(new Rect(0, 0, finalRect.Width, finalRect.Height));
        }

        protected override Microsoft.Maui.Graphics.Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            if (_invalid)
            {
                Rebuild();
                _invalid = false;
            }

            Measure(new Size(widthConstraint, heightConstraint));

            return ((IUIElement)this).DesiredSize.ToMauiSize();
        }

        public void Measure(Size availableSize)
        {
            ((IUIElement)this).Measure(availableSize);
        }

        public void ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).BindableProperty);

        public object? GetValue(IUIProperty property) => GetValue(((UIProperty)property).BindableProperty);

        public void SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).BindableProperty, value);

        public IUIElement GetVisualChild(int index)
        {
            if (_buildContent == null)
                throw new ArgumentOutOfRangeException("index", index, "Control returned null from build");
            if (index != 0)
                throw new ArgumentOutOfRangeException("index", index, "Index out of range; control only has a single visual child.");

            return _buildContent;
        }

        protected IUIElement? BuildContent => _buildContent;

        protected abstract IUIElement? Build();

        void Rebuild()
        { 
            _buildContent = Build();
        }
    }
}