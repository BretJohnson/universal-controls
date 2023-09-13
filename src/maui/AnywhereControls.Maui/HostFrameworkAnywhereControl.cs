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

        public int VisualChildrenCount => throw new NotImplementedException();

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

        public void Arrange(Rect finalRect)
        {
            ((IUIElement)this).Arrange(new Rect(0, 0, finalRect.Width, finalRect.Height));
        }

        public void Measure(Size availableSize)
        {

        }

        public void ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).BindableProperty);

        public object? GetValue(IUIProperty property) => GetValue(((UIProperty)property).BindableProperty);

        public object? ReadLocalValue(IUIProperty property) => GetValue(((UIProperty)property).BindableProperty);

        public void SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).BindableProperty, value);

        public IUIElement GetVisualChild(int index)
        {
            throw new NotImplementedException();
        }
    }
}