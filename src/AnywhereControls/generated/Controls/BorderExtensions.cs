// This file is generated from IBorder.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Controls
{
    public static class BorderExtensions
    {
        public static T Background<T>(this T border, IBrush value) where T : IBorder
        {
            border.Background = value;
            return border;
        }
        
        public static T BackgroundSizing<T>(this T border, BackgroundSizing value) where T : IBorder
        {
            border.BackgroundSizing = value;
            return border;
        }
        
        public static T BorderBrush<T>(this T border, IBrush value) where T : IBorder
        {
            border.BorderBrush = value;
            return border;
        }
        
        public static T BorderThickness<T>(this T border, Thickness value) where T : IBorder
        {
            border.BorderThickness = value;
            return border;
        }
        
        public static T Child<T>(this T border, IUIElement value) where T : IBorder
        {
            border.Child = value;
            return border;
        }
        
        public static T CornerRadius<T>(this T border, CornerRadius value) where T : IBorder
        {
            border.CornerRadius = value;
            return border;
        }
        
        public static T Padding<T>(this T border, Thickness value) where T : IBorder
        {
            border.Padding = value;
            return border;
        }
    }
}
