using System;

namespace AnywhereControls.WinUI
{
    public static class HorizontalAlignmentExtensions
    {
        public static Microsoft.UI.Xaml.HorizontalAlignment ToWinUIHorizontalAlignment(this HorizontalAlignment horizontalAligmnet) =>
            horizontalAligmnet switch
            {
                HorizontalAlignment.Left => Microsoft.UI.Xaml.HorizontalAlignment.Left,
                HorizontalAlignment.Center => Microsoft.UI.Xaml.HorizontalAlignment.Center,
                HorizontalAlignment.Right => Microsoft.UI.Xaml.HorizontalAlignment.Right,
                HorizontalAlignment.Stretch => Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(horizontalAligmnet), $"Invalid HorizontalAlignment value: {horizontalAligmnet}"),
            };

        public static HorizontalAlignment FromWinUIHorizontalAlignment(Microsoft.UI.Xaml.HorizontalAlignment horizontalAlignment) =>
            horizontalAlignment switch
            {
                Microsoft.UI.Xaml.HorizontalAlignment.Left => HorizontalAlignment.Left,
                Microsoft.UI.Xaml.HorizontalAlignment.Center => HorizontalAlignment.Center,
                Microsoft.UI.Xaml.HorizontalAlignment.Right => HorizontalAlignment.Right,
                Microsoft.UI.Xaml.HorizontalAlignment.Stretch => HorizontalAlignment.Stretch,
                _ => throw new ArgumentOutOfRangeException(nameof(horizontalAlignment), $"Invalid HorizontalAlignment value: {horizontalAlignment}"),
            };
    }
}
