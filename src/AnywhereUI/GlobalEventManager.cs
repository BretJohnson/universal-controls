// This was adapted from a subset of the WPF code here: https://github.com/dotnet/wpf/blob/e6a8177202c8c584c4b8d532dd8bc95388d3a07b/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/GlobalEventManager.cs

using System;
using System.Collections;

namespace AnywhereUI;

internal static class GlobalEventManager
{
    // must be used within a lock of GlobalEventManager.Synchronized
    private static ArrayList _globalIndexToEventMap = new ArrayList(50); // figure out what this number is in a typical scenario

    internal static object Synchronized = new object();

    // Registers a RoutedEvent with the given details
    // NOTE: The Name should be unique
    internal static RoutedEvent RegisterRoutedEvent(
        string name,
        RoutingStrategy routingStrategy,
        Type handlerType)
    {
        lock (Synchronized)
        {
            RoutedEvent routedEvent = new RoutedEvent(
                name,
                routingStrategy,
                handlerType);

            return routedEvent;
        }
    }

    internal static int GetNextAvailableGlobalIndex(object value)
    {
        int index;
        lock (Synchronized)
        {
            // Prevent GlobalIndex from overflow. RoutedEvents are meant to be static members and are to be registered 
            // only via static constructors. However there is no cheap way of ensuring this, without having to do a stack walk. Hence 
            // concievably people could register RoutedEvents via instance methods and therefore cause the GlobalIndex to 
            // overflow. This check will explicitly catch this error, instead of silently malfuntioning.
            if (_globalIndexToEventMap.Count >= Int32.MaxValue)
            {
                throw new InvalidOperationException("RoutedEvent/EventPrivateKey limit exceeded. RoutedEvents should be initialized once, typically in a static, but in this case they might be getting errorneously initialized in instance constructors, causing the limit to be exceeded.");
            }

            index = _globalIndexToEventMap.Add(value);
        }
        return index;
    }

    // Must be called from within a lock of GlobalEventManager.Synchronized
    internal static object EventFromGlobalIndex(int globalIndex)
    {
        return _globalIndexToEventMap[globalIndex];
    }
}
