namespace AnywhereControls.Avalonia
{
    public static class ColorExtensions
    {
        public static global::Avalonia.Media.Color ToAvaloniaColor(this Color color) => global::Avalonia.Media.Color.FromArgb(color.A, color.R, color.G, color.B);

        public static Color ToAnywhereControlsColor(this global::Avalonia.Media.Color color) => new Color(color.A, color.R, color.G, color.B);
    }
}
