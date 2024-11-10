using AnywhereControls;

namespace AnywhereControlsAvalonia;

public static class HorizontalAlignmentExtensions
{
    public static Avalonia.Layout.HorizontalAlignment ToAvaloniaHorizontalAlignment(this HorizontalAlignment horizontalAligmnet) =>
        horizontalAligmnet switch
        {
            HorizontalAlignment.Left => Avalonia.Layout.HorizontalAlignment.Left,
            HorizontalAlignment.Center => Avalonia.Layout.HorizontalAlignment.Center,
            HorizontalAlignment.Right => Avalonia.Layout.HorizontalAlignment.Right,
            HorizontalAlignment.Stretch => Avalonia.Layout.HorizontalAlignment.Stretch,
            _ => throw new ArgumentOutOfRangeException(nameof(horizontalAligmnet), $"Invalid HorizontalAlignment value: {horizontalAligmnet}"),
        };

    public static HorizontalAlignment ToAnywhereControlsHorizontalAlignment(this Avalonia.Layout.HorizontalAlignment horizontalAlignment) =>
        horizontalAlignment switch
        {
            Avalonia.Layout.HorizontalAlignment.Left => HorizontalAlignment.Left,
            Avalonia.Layout.HorizontalAlignment.Center => HorizontalAlignment.Center,
            Avalonia.Layout.HorizontalAlignment.Right => HorizontalAlignment.Right,
            Avalonia.Layout.HorizontalAlignment.Stretch => HorizontalAlignment.Stretch,
            _ => throw new ArgumentOutOfRangeException(nameof(horizontalAlignment), $"Invalid HorizontalAlignment value: {horizontalAlignment}"),
        };
}
