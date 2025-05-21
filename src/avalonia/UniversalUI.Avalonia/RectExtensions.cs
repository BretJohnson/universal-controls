using UniversalUI;

namespace AnywhereControlsAvalonia;

public static class RectExtensions
{
    public static Avalonia.Rect ToAvaloniaRect(this Rect rect) => new Avalonia.Rect(rect.X, rect.Y, rect.Width, rect.Height);

    public static Rect ToAnywhereControlsRect(this Avalonia.Rect rect) => new Rect(rect.X, rect.Y, rect.Width, rect.Height);
}
