// This file is generated from IRectangle.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Shapes;
using AnywhereUI.VisualFramework;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Shapes
{
    public class Rectangle : Shape, IRectangle, IDrawable
    {
        public static readonly Avalonia.StyledProperty<double> RadiusXProperty = AvaloniaProperty.Register<Rectangle, double>(nameof(RadiusX), 0.0);
        public static readonly Avalonia.StyledProperty<double> RadiusYProperty = AvaloniaProperty.Register<Rectangle, double>(nameof(RadiusY), 0.0);
        
        public double RadiusX
        {
            get => (double) GetValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
        
        public double RadiusY
        {
            get => (double) GetValue(RadiusYProperty);
            set => SetValue(RadiusYProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawRectangle(this);
    }
}
