// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

namespace UniversalUI.Media
{
    public static class PolyBezierSegmentExtensions
    {
        public static T Points<T>(this T polyBezierSegment, Points value) where T : IPolyBezierSegment
        {
            polyBezierSegment.Points = value;
            return polyBezierSegment;
        }
    }
}
