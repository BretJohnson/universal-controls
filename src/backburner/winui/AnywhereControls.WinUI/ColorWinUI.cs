namespace AnywhereControls.WinUI
{
    //[TypeConverter(typeof(ColorTypeConverter))]
    public struct ColorWinUI
    {
        public static readonly ColorWinUI Default = new ColorWinUI(Microsoft.StandardUI.Color.Default);
        public static readonly ColorWinUI Transparent = new ColorWinUI(Colors.Transparent);

        public static ColorWinUI FromColor(Color color) => new ColorWinUI(color);

        public static implicit operator ColorWinUI(Color color) => new ColorWinUI(color);

        // Auto properties
        public Color Color { get; }

        public ColorWinUI(Color color)
        {
            Color = color;
        }
    }
}
