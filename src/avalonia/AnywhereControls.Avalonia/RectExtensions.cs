namespace AnywhereControls.Avalonia;

public static class RectExtensions
{
    public static global::Avalonia.Rect ToAvaloniaRect(this Rect rect) => new global::Avalonia.Rect(rect.X, rect.Y, rect.Width, rect.Height);

    public static Rect ToAnywhereControlsRect(this global::Avalonia.Rect rect) => new Rect(rect.X, rect.Y, rect.Width, rect.Height);
}
