// This code was adapted from the WPF source here: https://github.com/dotnet/wpf/blob/e6a8177202c8c584c4b8d532dd8bc95388d3a07b/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/EventHandlersStore.cs

using System;
using AnywhereUI.Input;
using AnywhereUI.Utility;

namespace AnywhereUI;

/// <summary>
///     Container for the event handlers
/// </summary>
/// <remarks>
///     EventHandlersStore is a hashtable of handlers for a given EventPrivateKey or RoutedEvent
/// </remarks>
public class EventHandlersStore
{
    // Map of EventPrivateKey/RoutedEvent to Delegate/FrugalObjectList<RoutedEventHandlerInfo> (respectively)
    private FrugalMap _entries;

    /// <summary>
    ///     Constructor for EventHandlersStore
    /// </summary>
    public EventHandlersStore()
    {
        _entries = new FrugalMap();
    }

    /// <summary>
    /// Copy constructor for EventHandlersStore
    /// </summary>
    public EventHandlersStore(EventHandlersStore source)
    {
        _entries = source._entries;
    }

    /// <summary>
    ///     Adds a Clr event handler for the given EventPrivateKey to the store
    /// </summary>
    /// <param name="key">
    ///     Private key for the event
    /// </param>
    /// <param name="handler">
    ///     Event handler
    /// </param>
    public void Add(EventPrivateKey key, Delegate handler)
    {
        // Get the entry corresponding to the given key
        Delegate? existingDelegate = this[key];

        if (existingDelegate == null)
        {
            _entries[key.GlobalIndex] = handler;
        }
        else
        {
            _entries[key.GlobalIndex] = Delegate.Combine(existingDelegate, handler);
        }
    }

    /// <summary>
    ///     Removes an instance of the specified Clr event handler for the given EventPrivateKey from the store
    /// </summary>
    /// <param name="key">
    ///     Private key for the event
    /// </param>
    /// <param name="handler">
    ///     Event handler
    /// </param>
    /// <remarks>
    ///     NOTE: This method does nothing if no matching handler instances are found in the store
    /// </remarks>
    public void Remove(EventPrivateKey key, Delegate handler)
    {
        // Get the entry corresponding to the given key
        Delegate? existingDelegate = this[key];
        if (existingDelegate != null)
        {
            existingDelegate = Delegate.Remove(existingDelegate, handler);
            if (existingDelegate == null)
            {
                // last handler for this event was removed -- reclaim space in
                // underlying FrugalMap by setting value to DependencyProperty.UnsetValue
                _entries[key.GlobalIndex] = UnsetValue.Instance;
            }
            else
            {
                _entries[key.GlobalIndex] = existingDelegate;
            }
        }
    }

    /// <summary>
    ///     Gets all the handlers for the given EventPrivateKey
    /// </summary>
    /// <param name="key">
    ///     Private key for the event
    /// </param>
    /// <returns>
    ///     Combined delegate or null if no match found
    /// </returns>
    /// <remarks>
    ///     This method is not exposing a security risk for the reason 
    ///     that the EventPrivateKey for the events will themselves be 
    ///     private to the declaring class. This will be enforced via fxcop rules.
    /// </remarks>
    public Delegate? Get(EventPrivateKey key)
    {
        // Return the handlers corresponding to the given key
        return this[key];
    }

    /// <summary>
    ///     Adds a routed event handler for the given 
    ///     RoutedEvent to the store
    /// </summary>
    public bool AddRoutedEventHandler(RoutedEvent routedEvent, Delegate handler)
    {
        if (!routedEvent.IsLegalHandler(handler))
        {
            throw new ArgumentException("Handler type is mismatched.");
        }

        RoutedEventHandlerInfo routedEventHandlerInfo = new RoutedEventHandlerInfo(handler);

        // Get the entry corresponding to the given RoutedEvent
        FrugalObjectList<RoutedEventHandlerInfo>? handlers = this[routedEvent];
        if (handlers == null)
        {
            handlers = new FrugalObjectList<RoutedEventHandlerInfo>(1);
            _entries[routedEvent.GlobalIndex] = handlers;
            handlers.Add(routedEventHandlerInfo);
            return true;
        }
        else
        {
            handlers.Add(routedEventHandlerInfo);
            return false;
        }
    }

    /// <summary>
    ///     Adds a routed event handler for the given RoutedEvent to the store
    /// </summary>
    public bool AddRoutedEventHandler(RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
    {
        if (!routedEvent.IsLegalHandler(handler))
        {
            throw new ArgumentException("Handler type is mismatched.");
        }

        RoutedEventHandlerInfo routedEventHandlerInfo = new RoutedEventHandlerInfo(handler, handledEventsToo);

        // Get the entry corresponding to the given RoutedEvent
        FrugalObjectList<RoutedEventHandlerInfo>? handlers = this[routedEvent];
        if (handlers == null)
        {
            handlers = new FrugalObjectList<RoutedEventHandlerInfo>(1);
            _entries[routedEvent.GlobalIndex] = handlers;
            handlers.Add(routedEventHandlerInfo);
            return true;
        }
        else
        {
            handlers.Add(routedEventHandlerInfo);
            return false;
        }
    }

    /// <summary>
    ///     Removes an instance of the specified routed event handler for the given RoutedEvent from the store
    /// </summary>
    /// <remarks>
    ///     NOTE: This method does nothing if no matching handler instances are found in the store
    /// </remarks>
    public bool RemoveRoutedEventHandler(RoutedEvent routedEvent, Delegate handler)
    {
        // Get the entry corresponding to the given RoutedEvent
        FrugalObjectList<RoutedEventHandlerInfo>? handlers = this[routedEvent];
        if (handlers == null || handlers.Count <= 0)
        {
            return false;
        }

        if ((handlers.Count == 1) && (handlers[0].Handler == handler))
        {
            // this is the only handler for this event and it's being removed
            // reclaim space in underlying FrugalMap by setting value to UnsetValue
            _entries[routedEvent.GlobalIndex] = UnsetValue.Instance;
            return true;
        }
        else
        {
            // When a matching instance is found remove it
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Handler == handler)
                {
                    handlers.RemoveAt(i);
                    break;
                }
            }
            return false;
        }
    }

    /// <summary>
    ///     Determines whether the given RoutedEvent exists in the store.
    /// </summary>
    /// <param name="routedEvent">
    ///     the RoutedEvent of the event.
    /// </param>

    public bool Contains(RoutedEvent routedEvent)
    {
        FrugalObjectList<RoutedEventHandlerInfo>? handlers = this[routedEvent];
        return handlers != null && handlers.Count != 0;
    }

    /// <summary>
    ///     Get all the event handlers in this store for the given routed event
    /// </summary>
    public RoutedEventHandlerInfo[]? GetRoutedEventHandlers(RoutedEvent routedEvent) =>
        this[routedEvent]?.ToArray();

    public void RaiseHandleableEvent(RoutedEvent routedEvent, object sender, IHandleableRoutedEventArgs e)
    {
        FrugalObjectList<RoutedEventHandlerInfo>? instanceListeners = this[routedEvent];

        if (instanceListeners != null)
        {
            for (int i = 0; i < instanceListeners.Count; i++)
            {
                instanceListeners[i].InvokeHandleableEventHandler(sender, e);
            }
        }
    }

    public void RaiseNonhandleableEvent(RoutedEvent routedEvent, object sender, IRoutedEventArgs e)
    {
        FrugalObjectList<RoutedEventHandlerInfo>? instanceListeners = this[routedEvent];

        if (instanceListeners != null)
        {
            for (int i = 0; i < instanceListeners.Count; i++)
            {
                instanceListeners[i].InvokeNonhandleableEventHander(sender, e);
            }
        }
    }

    // Returns Handlers for the given key
    internal FrugalObjectList<RoutedEventHandlerInfo>? this[RoutedEvent key]
    {
        get
        {
            object list = _entries[key.GlobalIndex];
            return list == UnsetValue.Instance ? null : (FrugalObjectList<RoutedEventHandlerInfo>)list;
        }
    }

    internal Delegate? this[EventPrivateKey key]
    {
        get
        {
            object existingDelegate = _entries[key.GlobalIndex];
            return existingDelegate == UnsetValue.Instance ? null : (Delegate)existingDelegate;
        }
    }

    internal int Count => _entries.Count;
}