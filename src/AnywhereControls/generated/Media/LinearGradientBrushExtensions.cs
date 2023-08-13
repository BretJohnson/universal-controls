// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    public static class LinearGradientBrushExtensions
    {
        public static T StartPoint<T>(this T linearGradientBrush, Point value) where T : ILinearGradientBrush
        {
            linearGradientBrush.StartPoint = value;
            return linearGradientBrush;
        }
        
        public static T EndPoint<T>(this T linearGradientBrush, Point value) where T : ILinearGradientBrush
        {
            linearGradientBrush.EndPoint = value;
            return linearGradientBrush;
        }
    }
}
