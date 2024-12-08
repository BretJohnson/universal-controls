// This file is generated from IArcSegment.cs. Update the source file to change its contents.

namespace AnywhereUI.Media
{
    public static class ArcSegmentExtensions
    {
        public static T Point<T>(this T arcSegment, Point value) where T : IArcSegment
        {
            arcSegment.Point = value;
            return arcSegment;
        }
        
        public static T Size<T>(this T arcSegment, Size value) where T : IArcSegment
        {
            arcSegment.Size = value;
            return arcSegment;
        }
        
        public static T RotationAngle<T>(this T arcSegment, double value) where T : IArcSegment
        {
            arcSegment.RotationAngle = value;
            return arcSegment;
        }
        
        public static T IsLargeArc<T>(this T arcSegment, bool value) where T : IArcSegment
        {
            arcSegment.IsLargeArc = value;
            return arcSegment;
        }
        
        public static T SweepDirection<T>(this T arcSegment, SweepDirection value) where T : IArcSegment
        {
            arcSegment.SweepDirection = value;
            return arcSegment;
        }
    }
}
