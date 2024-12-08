// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;

namespace AnywhereControls.WinForms.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly UIProperty ColorProperty = new UIProperty(nameof(Color), Colors.Transparent);
        
        public Color Color
        {
            get => (Color) GetNonNullValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
