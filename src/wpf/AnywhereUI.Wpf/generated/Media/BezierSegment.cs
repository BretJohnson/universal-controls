// This file is generated from IBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Media
{
    public class BezierSegment : PathSegment, IBezierSegment
    {
        public static readonly DependencyProperty Point1Property = PropertyUtils.Register(nameof(Point1), typeof(Point), typeof(BezierSegment), default(Point));
        public static readonly DependencyProperty Point2Property = PropertyUtils.Register(nameof(Point2), typeof(Point), typeof(BezierSegment), default(Point));
        public static readonly DependencyProperty Point3Property = PropertyUtils.Register(nameof(Point3), typeof(Point), typeof(BezierSegment), default(Point));
        
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
