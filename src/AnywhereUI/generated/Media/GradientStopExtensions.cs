// This file is generated from IGradientStop.cs. Update the source file to change its contents.

namespace AnywhereUI.Media
{
    public static class GradientStopExtensions
    {
        public static T Color<T>(this T gradientStop, Color value) where T : IGradientStop
        {
            gradientStop.Color = value;
            return gradientStop;
        }
        
        public static T Offset<T>(this T gradientStop, double value) where T : IGradientStop
        {
            gradientStop.Offset = value;
            return gradientStop;
        }
    }
}
