// This code was adapted from the WPF source here: https://github.com/dotnet/wpf/blob/b47e1312c9bfe069a689d1f53f3b8caa09018265/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/RoutingStrategy.cs

namespace AnywhereControls;

/// <summary>
///     Routing strategy that's used for the event: Tunnel, Bubble, or Direct.
///     Note that Anywhere Controls doesn't currently do any event routing, just relying on
///     the host framework to route. The routing strategy here is the one that's
///     normally used by the host framework for the event, just for informational purposes.
/// </summary>
public enum RoutingStrategy
{
    /// <summary>
    ///     Tunnel 
    /// </summary>
    /// <remarks>
    ///     Route the event starting at the root of 
    ///     the visual tree and ending with the source
    /// </remarks>
    Tunnel,

    /// <summary>
    ///     Bubble 
    /// </summary>
    /// <remarks>
    ///     Route the event starting at the source 
    ///     and ending with the root of the visual tree
    /// </remarks>
    Bubble,

    /// <summary>
    ///     Direct 
    /// </summary>
    /// <remarks>
    ///     Raise the event at the source only.
    /// </remarks>
    Direct
}