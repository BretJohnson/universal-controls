using System.ComponentModel;
using AnywhereControls.Maui.Converters;

namespace AnywhereControls.Maui
{
    [TypeConverter(typeof(ColorTypeConverter))]
    public struct ColorMaui
    {
        public static readonly ColorMaui Default = new ColorMaui(Microsoft.StandardUI.Color.Default);
        public static readonly ColorMaui Transparent = new ColorMaui(Colors.Transparent);

        public static ColorMaui FromColor(Color color) => new ColorMaui(color);

        // Auto properties
        public Color Color { get; }

        public ColorMaui(Color color)
        {
            Color = color;
        }
    }
}
