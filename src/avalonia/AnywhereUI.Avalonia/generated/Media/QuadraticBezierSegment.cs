// This file is generated from IQuadraticBezierSegment.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class QuadraticBezierSegment : PathSegment, IQuadraticBezierSegment
    {
        public static readonly Avalonia.StyledProperty<Point> Point1Property = AvaloniaProperty.Register<QuadraticBezierSegment, Point>(nameof(Point1), default(Point));
        public static readonly Avalonia.StyledProperty<Point> Point2Property = AvaloniaProperty.Register<QuadraticBezierSegment, Point>(nameof(Point2), default(Point));
        
        public Point Point1
        {
            get => (Point) GetValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        
        public Point Point2
        {
            get => (Point) GetValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
    }
}
