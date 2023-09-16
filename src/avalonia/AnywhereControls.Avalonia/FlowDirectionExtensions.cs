namespace AnywhereControls.Avalonia
{
    public static class FlowDirectionExtensions
    {
        public static global::Avalonia.Media.FlowDirection ToAvaloniaFlowDirection(this FlowDirection flowDirection) =>
            flowDirection switch
            {
                FlowDirection.LeftToRight => global::Avalonia.Media.FlowDirection.LeftToRight,
                FlowDirection.RightToLeft => global::Avalonia.Media.FlowDirection.RightToLeft,
                _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
            };

        public static FlowDirection ToStandardUIFlowDirection(this global::Avalonia.Media.FlowDirection flowDirection) =>
            flowDirection switch
            {
                global::Avalonia.Media.FlowDirection.LeftToRight => FlowDirection.LeftToRight,
                global::Avalonia.Media.FlowDirection.RightToLeft => FlowDirection.RightToLeft,
                _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
            };
    }
}
