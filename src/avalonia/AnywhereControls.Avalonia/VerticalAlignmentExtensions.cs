using AnywhereControls;

namespace AnywhereControlsAvalonia
{
    public static class VerticalAlignmentExtensions
    {
        public static Avalonia.Layout.VerticalAlignment ToAvaloniaVerticalAlignment(this VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                VerticalAlignment.Top => Avalonia.Layout.VerticalAlignment.Top,
                VerticalAlignment.Center => Avalonia.Layout.VerticalAlignment.Center,
                VerticalAlignment.Bottom => Avalonia.Layout.VerticalAlignment.Bottom,
                VerticalAlignment.Stretch => Avalonia.Layout.VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };

        public static VerticalAlignment ToAnywhereControlsVerticalAlignment(this Avalonia.Layout.VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                Avalonia.Layout.VerticalAlignment.Top => VerticalAlignment.Top,
                Avalonia.Layout.VerticalAlignment.Center => VerticalAlignment.Center,
                Avalonia.Layout.VerticalAlignment.Bottom => VerticalAlignment.Bottom,
                Avalonia.Layout.VerticalAlignment.Stretch => VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };
    }
}
