// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    public static class RadialGradientBrushExtensions
    {
        public static T Center<T>(this T radialGradientBrush, Point value) where T : IRadialGradientBrush
        {
            radialGradientBrush.Center = value;
            return radialGradientBrush;
        }
        
        public static T GradientOrigin<T>(this T radialGradientBrush, Point value) where T : IRadialGradientBrush
        {
            radialGradientBrush.GradientOrigin = value;
            return radialGradientBrush;
        }
        
        public static T RadiusX<T>(this T radialGradientBrush, double value) where T : IRadialGradientBrush
        {
            radialGradientBrush.RadiusX = value;
            return radialGradientBrush;
        }
    }
}
