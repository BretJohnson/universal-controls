// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Media
{
    public static class PolyLineSegmentExtensions
    {
        public static T Points<T>(this T polyLineSegment, Points value) where T : IPolyLineSegment
        {
            polyLineSegment.Points = value;
            return polyLineSegment;
        }
    }
}
