// This file is generated from IBezierSegment.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;

namespace AnywhereControls.Mac.Media
{
    public class BezierSegment : PathSegment, IBezierSegment
    {
        public static readonly UIProperty Point1Property = new UIProperty(nameof(Point1), default(Point));
        public static readonly UIProperty Point2Property = new UIProperty(nameof(Point2), default(Point));
        public static readonly UIProperty Point3Property = new UIProperty(nameof(Point3), default(Point));
        
        public Point Point1
        {
            get => (Point) GetNonNullValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        
        public Point Point2
        {
            get => (Point) GetNonNullValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
        
        public Point Point3
        {
            get => (Point) GetNonNullValue(Point3Property);
            set => SetValue(Point3Property, value);
        }
    }
}
