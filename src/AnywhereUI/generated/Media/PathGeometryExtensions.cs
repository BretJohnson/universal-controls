// This file is generated from IPathGeometry.cs. Update the source file to change its contents.

namespace AnywhereUI.Media
{
    public static class PathGeometryExtensions
    {
        public static T Figures<T>(this T pathGeometry, params IPathFigure[] value) where T : IPathGeometry
        {
            pathGeometry.Figures.Set(value);
            return pathGeometry;
        }
        
        public static T FillRule<T>(this T pathGeometry, FillRule value) where T : IPathGeometry
        {
            pathGeometry.FillRule = value;
            return pathGeometry;
        }
    }
}
