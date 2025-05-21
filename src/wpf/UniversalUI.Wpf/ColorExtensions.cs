namespace UniversalUI.Wpf
{
    public static class ColorExtensions
    {
        public static System.Windows.Media.Color ToWpfColor(this Color color) => System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);

        public static Color ToAnywhereControlsColor(this System.Windows.Media.Color color) => new Color(color.A, color.R, color.G, color.B);
    }
}
