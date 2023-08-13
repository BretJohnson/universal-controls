using System;

namespace Microsoft.StandardUI.WinUI
{
    public static class FlowDirectionExtensions
    {
        public static Microsoft.UI.Xaml.FlowDirection ToWinUIFlowDirection(this FlowDirection flowDirection) =>
            flowDirection switch
            {
                FlowDirection.LeftToRight => Microsoft.UI.Xaml.FlowDirection.LeftToRight,
                FlowDirection.RightToLeft => Microsoft.UI.Xaml.FlowDirection.RightToLeft,
                _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
            };

        public static FlowDirection ToStandardUIFlowDirection(Microsoft.UI.Xaml.FlowDirection flowDirection) =>
            flowDirection switch
            {
                Microsoft.UI.Xaml.FlowDirection.LeftToRight => FlowDirection.LeftToRight,
                Microsoft.UI.Xaml.FlowDirection.RightToLeft => FlowDirection.RightToLeft,
                _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
            };
    }
}
