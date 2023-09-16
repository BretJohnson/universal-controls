namespace AnywhereControls.Avalonia
{
    public static class ThicknessExtensions
    {
        public static global::Avalonia.Thickness ToAvaloniaThickness(this Thickness thickness) => new global::Avalonia.Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);

        public static Thickness ToAnywhereControlsThickness(this global::Avalonia.Thickness thickness) => new Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
    }
}
