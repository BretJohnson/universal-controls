using UniversalUI;

namespace AnywhereControlsAvalonia;

public static class ColorExtensions
{
    public static Avalonia.Media.Color ToAvaloniaColor(this Color color) => Avalonia.Media.Color.FromArgb(color.A, color.R, color.G, color.B);

    public static Color ToAnywhereControlsColor(this Avalonia.Media.Color color) => new Color(color.A, color.R, color.G, color.B);
}
