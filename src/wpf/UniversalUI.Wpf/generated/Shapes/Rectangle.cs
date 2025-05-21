// This file is generated from IRectangle.cs. Update the source file to change its contents.

using UniversalUI.Shapes;
using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf.Shapes
{
    public class Rectangle : Shape, IRectangle, IDrawable
    {
        public static readonly DependencyProperty RadiusXProperty = PropertyUtils.Register(nameof(RadiusX), typeof(double), typeof(Rectangle), 0.0);
        public static readonly DependencyProperty RadiusYProperty = PropertyUtils.Register(nameof(RadiusY), typeof(double), typeof(Rectangle), 0.0);
        
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
