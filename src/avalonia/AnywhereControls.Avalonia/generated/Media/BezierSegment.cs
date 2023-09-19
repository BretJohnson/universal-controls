// This file is generated from IBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class BezierSegment : PathSegment, IBezierSegment
    {
        public static readonly Avalonia.StyledProperty<Point> Point1Property = AvaloniaProperty.Register<BezierSegment, Point>(nameof(Point1), default(Point));
        public static readonly Avalonia.StyledProperty<Point> Point2Property = AvaloniaProperty.Register<BezierSegment, Point>(nameof(Point2), default(Point));
        public static readonly Avalonia.StyledProperty<Point> Point3Property = AvaloniaProperty.Register<BezierSegment, Point>(nameof(Point3), default(Point));
        
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
        
        public Point Point3
        {
            get => (Point) GetValue(Point3Property);
            set => SetValue(Point3Property, value);
        }
    }
}
