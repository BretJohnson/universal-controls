using AnywhereUI;

namespace AnywhereControlsAvalonia;

public static class SizeExtensions
{
    public static Avalonia.Size ToAvaloniaSize(this Size size) => new Avalonia.Size(size.Width, size.Height);

    public static Size ToAnywhereControlsSize(this Avalonia.Size size) => new Size(size.Width, size.Height);
}
