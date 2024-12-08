// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

namespace AnywhereUI.Media
{
    public static class SolidColorBrushExtensions
    {
        public static T Color<T>(this T solidColorBrush, Color value) where T : ISolidColorBrush
        {
            solidColorBrush.Color = value;
            return solidColorBrush;
        }
    }
}
