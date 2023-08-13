namespace AnywhereControls.WinUI
{
    public static class ColorExtensions
    {
        public static global::Windows.UI.Color ToWinUIColor(this Color color) =>
            global::Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B);

        public static Color ToStandardUIColor(this global::Windows.UI.Color color) =>
            new Color(color.A, color.R, color.G, color.B);
    }
}
