using System.ComponentModel;
using Microsoft.Maui.Graphics;
using AnywhereControls.Wpf.Converters;

namespace AnywhereControls.Wpf
{
    [TypeConverter(typeof(ColorTypeConverter))]
    public struct ColorWpf
    {
        public static readonly ColorWpf Transparent = new ColorWpf(Colors.Transparent);

        public static ColorWpf FromColor(Color color) => new ColorWpf(color);

        public static implicit operator ColorWpf(Color color) => new ColorWpf(color);

        // Auto properties
        public Color Color { get; }

        public ColorWpf(Color color)
        {
            Color = color;
        }
    }
}
