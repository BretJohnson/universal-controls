// This file is generated from IPolyline.cs. Update the source file to change its contents.

using UniversalUI.Media;

namespace UniversalUI.Shapes
{
    public static class PolylineExtensions
    {
        public static T FillRule<T>(this T polyline, FillRule value) where T : IPolyline
        {
            polyline.FillRule = value;
            return polyline;
        }
        
        public static T Points<T>(this T polyline, Points value) where T : IPolyline
        {
            polyline.Points = value;
            return polyline;
        }
    }
}
