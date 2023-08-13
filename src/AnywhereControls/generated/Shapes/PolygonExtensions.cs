// This file is generated from IPolygon.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Shapes
{
    public static class PolygonExtensions
    {
        public static T FillRule<T>(this T polygon, FillRule value) where T : IPolygon
        {
            polygon.FillRule = value;
            return polygon;
        }
        
        public static T Points<T>(this T polygon, Points value) where T : IPolygon
        {
            polygon.Points = value;
            return polygon;
        }
    }
}
