// This file is generated from IQuadraticBezierSegment.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Media
{
    public static class QuadraticBezierSegmentExtensions
    {
        public static T Point1<T>(this T quadraticBezierSegment, Point value) where T : IQuadraticBezierSegment
        {
            quadraticBezierSegment.Point1 = value;
            return quadraticBezierSegment;
        }
        
        public static T Point2<T>(this T quadraticBezierSegment, Point value) where T : IQuadraticBezierSegment
        {
            quadraticBezierSegment.Point2 = value;
            return quadraticBezierSegment;
        }
    }
}
