// This file is generated from IGeometry.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Media
{
    public static class GeometryExtensions
    {
        public static T StandardFlatteningTolerance<T>(this T geometry, double value) where T : IGeometry
        {
            geometry.StandardFlatteningTolerance = value;
            return geometry;
        }
        
        public static T Transform<T>(this T geometry, ITransform value) where T : IGeometry
        {
            geometry.Transform = value;
            return geometry;
        }
    }
}
