namespace UniversalUI.Maui
{
    public static class ColorExtensions
    {
        public static Microsoft.Maui.Graphics.Color ToMauiColor(this Color color)
            => Microsoft.Maui.Graphics.Color.FromRgba(color.R, color.G, color.B, color.A);

        public static Color ToStandardUIColor(this Microsoft.Maui.Graphics.Color color)
            => new Color((byte)color.Alpha, (byte)color.Red, (byte)color.Green, (byte)color.Blue);
    }
}