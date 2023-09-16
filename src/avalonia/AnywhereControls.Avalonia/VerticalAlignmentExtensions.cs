namespace AnywhereControls.Avalonia
{
    public static class VerticalAlignmentExtensions
    {
        public static global::Avalonia.Layout.VerticalAlignment ToAvaloniaVerticalAlignment(this VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                VerticalAlignment.Top => global::Avalonia.Layout.VerticalAlignment.Top,
                VerticalAlignment.Center => global::Avalonia.Layout.VerticalAlignment.Center,
                VerticalAlignment.Bottom => global::Avalonia.Layout.VerticalAlignment.Bottom,
                VerticalAlignment.Stretch => global::Avalonia.Layout.VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };

        public static VerticalAlignment ToAnywhereControlsVerticalAlignment(this global::Avalonia.Layout.VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                global::Avalonia.Layout.VerticalAlignment.Top => VerticalAlignment.Top,
                global::Avalonia.Layout.VerticalAlignment.Center => VerticalAlignment.Center,
                global::Avalonia.Layout.VerticalAlignment.Bottom => VerticalAlignment.Bottom,
                global::Avalonia.Layout.VerticalAlignment.Stretch => VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };
    }
}
