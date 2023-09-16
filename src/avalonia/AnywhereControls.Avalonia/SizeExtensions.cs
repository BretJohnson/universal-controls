namespace AnywhereControls.Avalonia;

public static class SizeExtensions
{
    public static global::Avalonia.Size ToAvaloniaSize(this Size size) => new global::Avalonia.Size(size.Width, size.Height);

    public static Size ToAnywhereControlsSize(this global::Avalonia.Size size) => new Size(size.Width, size.Height);
}
