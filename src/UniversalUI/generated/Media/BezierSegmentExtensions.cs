// This file is generated from IBezierSegment.cs. Update the source file to change its contents.

namespace UniversalUI.Media
{
    public static class BezierSegmentExtensions
    {
        public static T Point1<T>(this T bezierSegment, Point value) where T : IBezierSegment
        {
            bezierSegment.Point1 = value;
            return bezierSegment;
        }
        
        public static T Point2<T>(this T bezierSegment, Point value) where T : IBezierSegment
        {
            bezierSegment.Point2 = value;
            return bezierSegment;
        }
        
        public static T Point3<T>(this T bezierSegment, Point value) where T : IBezierSegment
        {
            bezierSegment.Point3 = value;
            return bezierSegment;
        }
    }
}
