// This file is generated from ICanvas.cs. Update the source file to change its contents.

using AnywhereControls.Controls;
using ICanvas = AnywhereControls.Controls.ICanvas;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class Canvas : Panel, ICanvas
    {
        public static readonly Avalonia.AttachedProperty<double> LeftProperty = AvaloniaProperty.RegisterAttached<Canvas, Avalonia.Controls.Control, double>("Left", 0.0);
        public static readonly Avalonia.AttachedProperty<double> TopProperty = AvaloniaProperty.RegisterAttached<Canvas, Avalonia.Controls.Control, double>("Top", 0.0);
        
        public static double GetLeft(Avalonia.Controls.Control element) => (double) element.GetValue(LeftProperty);
        public static void SetLeft(Avalonia.Controls.Control element, double value) => element.SetValue(LeftProperty, value);
        
        public static double GetTop(Avalonia.Controls.Control element) => (double) element.GetValue(TopProperty);
        public static void SetTop(Avalonia.Controls.Control element, double value) => element.SetValue(TopProperty, value);
        
        protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>
            CanvasLayoutManager.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();
        
        protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>
            CanvasLayoutManager.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();
    }
}
