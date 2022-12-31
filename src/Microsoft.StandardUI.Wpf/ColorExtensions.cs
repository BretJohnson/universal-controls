using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Wpf
{
    public static class ColorExtensions
    {
        public static System.Windows.Media.Color ToWpfColor(this Color color)
        {
            color.ToRgba(out byte red, out byte green, out byte blue, out byte alpha);
            return System.Windows.Media.Color.FromArgb(red, green, blue, alpha);
        }

        public static Color ToStandardUIColor(this System.Windows.Media.Color color) => new Color(color.A, color.R, color.G, color.B);
    }
}
