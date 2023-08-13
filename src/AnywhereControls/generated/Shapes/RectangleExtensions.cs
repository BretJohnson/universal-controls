// This file is generated from IRectangle.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Shapes
{
    public static class RectangleExtensions
    {
        public static T RadiusX<T>(this T rectangle, double value) where T : IRectangle
        {
            rectangle.RadiusX = value;
            return rectangle;
        }
        
        public static T RadiusY<T>(this T rectangle, double value) where T : IRectangle
        {
            rectangle.RadiusY = value;
            return rectangle;
        }
    }
}
