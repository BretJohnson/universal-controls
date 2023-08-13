using System;

namespace AnywhereControls.WinUI
{
    public static class VerticalAlignmentExtensions
    {
        public static Microsoft.UI.Xaml.VerticalAlignment ToWinUIVerticalAlignment(this VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                VerticalAlignment.Top => Microsoft.UI.Xaml.VerticalAlignment.Top,
                VerticalAlignment.Center => Microsoft.UI.Xaml.VerticalAlignment.Center,
                VerticalAlignment.Bottom => Microsoft.UI.Xaml.VerticalAlignment.Bottom,
                VerticalAlignment.Stretch => Microsoft.UI.Xaml.VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };

        public static VerticalAlignment ToStandardUIVerticalAlignment(this Microsoft.UI.Xaml.VerticalAlignment verticalAlignment) =>
            verticalAlignment switch
            {
                Microsoft.UI.Xaml.VerticalAlignment.Top => VerticalAlignment.Top,
                Microsoft.UI.Xaml.VerticalAlignment.Center => VerticalAlignment.Center,
                Microsoft.UI.Xaml.VerticalAlignment.Bottom => VerticalAlignment.Bottom,
                Microsoft.UI.Xaml.VerticalAlignment.Stretch => VerticalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(verticalAlignment), $"Invalid VerticalAlignment value: {verticalAlignment}"),
            };
    }
}
