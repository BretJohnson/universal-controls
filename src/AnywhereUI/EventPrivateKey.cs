// This code was adapted from the WPF source here: https://github.com/dotnet/wpf/blob/e6a8177202c8c584c4b8d532dd8bc95388d3a07b/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/EventPrivateKey.cs

namespace AnywhereUI;

/// <summary>
///     This class is meant to provide identification for Clr events whose handlers are stored into EventHandlersStore
/// </summary>
/// <remarks>
///     This type has been specifically added so that it is easy to enforce via fxcop rules or such that 
///     event keys of this type must be private static fields on the declaring class.
/// </remarks>
public class EventPrivateKey
{
    private int _globalIndex;

    public EventPrivateKey()
    {
        _globalIndex = GlobalEventManager.GetNextAvailableGlobalIndex(this);
    }

    internal int GlobalIndex => _globalIndex;
}
