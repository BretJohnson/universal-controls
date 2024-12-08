using AnywhereUI;

namespace AnywhereControlsAvalonia;

public static class FlowDirectionExtensions
{
    public static Avalonia.Media.FlowDirection ToAvaloniaFlowDirection(this FlowDirection flowDirection) =>
        flowDirection switch
        {
            FlowDirection.LeftToRight => Avalonia.Media.FlowDirection.LeftToRight,
            FlowDirection.RightToLeft => Avalonia.Media.FlowDirection.RightToLeft,
            _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
        };

    public static FlowDirection ToStandardUIFlowDirection(this Avalonia.Media.FlowDirection flowDirection) =>
        flowDirection switch
        {
            Avalonia.Media.FlowDirection.LeftToRight => FlowDirection.LeftToRight,
            Avalonia.Media.FlowDirection.RightToLeft => FlowDirection.RightToLeft,
            _ => throw new ArgumentOutOfRangeException(nameof(flowDirection), $"Invalid FlowDirection value: {flowDirection}"),
        };
}
