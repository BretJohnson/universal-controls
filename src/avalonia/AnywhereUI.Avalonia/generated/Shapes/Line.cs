// This file is generated from ILine.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Shapes;
using AnywhereUI.VisualFramework;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Shapes
{
    public class Line : Shape, ILine, IDrawable
    {
        public static readonly Avalonia.StyledProperty<double> X1Property = AvaloniaProperty.Register<Line, double>(nameof(X1), 0.0);
        public static readonly Avalonia.StyledProperty<double> Y1Property = AvaloniaProperty.Register<Line, double>(nameof(Y1), 0.0);
        public static readonly Avalonia.StyledProperty<double> X2Property = AvaloniaProperty.Register<Line, double>(nameof(X2), 0.0);
        public static readonly Avalonia.StyledProperty<double> Y2Property = AvaloniaProperty.Register<Line, double>(nameof(Y2), 0.0);
        
        public double X1
        {
            get => (double) GetValue(X1Property);
            set => SetValue(X1Property, value);
        }
        
        public double Y1
        {
            get => (double) GetValue(Y1Property);
            set => SetValue(Y1Property, value);
        }
        
        public double X2
        {
            get => (double) GetValue(X2Property);
            set => SetValue(X2Property, value);
        }
        
        public double Y2
        {
            get => (double) GetValue(Y2Property);
            set => SetValue(Y2Property, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawLine(this);
    }
}
