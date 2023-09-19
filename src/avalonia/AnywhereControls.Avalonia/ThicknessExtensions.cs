using AnywhereControls;

namespace AnywhereControlsAvalonia
{
    public static class ThicknessExtensions
    {
        public static Avalonia.Thickness ToAvaloniaThickness(this Thickness thickness) => new Avalonia.Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);

        public static Thickness ToAnywhereControlsThickness(this Avalonia.Thickness thickness) => new Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
    }
}
