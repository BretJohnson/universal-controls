namespace AnywhereControls.Avalonia
{
    public static class HorizontalAlignmentExtensions
    {
        public static global::Avalonia.Layout.HorizontalAlignment ToAvaloniaHorizontalAlignment(this HorizontalAlignment horizontalAligmnet) =>
            horizontalAligmnet switch
            {
                HorizontalAlignment.Left => global::Avalonia.Layout.HorizontalAlignment.Left,
                HorizontalAlignment.Center => global::Avalonia.Layout.HorizontalAlignment.Center,
                HorizontalAlignment.Right => global::Avalonia.Layout.HorizontalAlignment.Right,
                HorizontalAlignment.Stretch => global::Avalonia.Layout.HorizontalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(horizontalAligmnet), $"Invalid HorizontalAlignment value: {horizontalAligmnet}"),
            };

        public static HorizontalAlignment ToAnywhereControlsHorizontalAlignment(this global::Avalonia.Layout.HorizontalAlignment horizontalAlignment) =>
            horizontalAlignment switch
            {
                global::Avalonia.Layout.HorizontalAlignment.Left => HorizontalAlignment.Left,
                global::Avalonia.Layout.HorizontalAlignment.Center => HorizontalAlignment.Center,
                global::Avalonia.Layout.HorizontalAlignment.Right => HorizontalAlignment.Right,
                global::Avalonia.Layout.HorizontalAlignment.Stretch => HorizontalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(horizontalAlignment), $"Invalid HorizontalAlignment value: {horizontalAlignment}"),
            };
    }
}
