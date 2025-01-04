// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly Avalonia.StyledProperty<Point> PointProperty = AvaloniaProperty.Register<LineSegment, Point>(nameof(Point), default(Point));
        
        public Point Point
        {
            get => (Point) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
    }
}
