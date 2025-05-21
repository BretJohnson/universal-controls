// This was adapted from the WPF source here: https://github.com/dotnet/wpf/blob/b47e1312c9bfe069a689d1f53f3b8caa09018265/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/RoutedEvent.cs

using System;
using UniversalUI.Input;

namespace UniversalUI;

/// <summary>
///     RoutedEvent is a unique identifier for any registered RoutedEvent
/// </summary>
/// <remarks>
///     RoutedEvent constitutes the <para/>
///     <see cref="RoutedEvent.Name"/>, <para/>
///     <see cref="RoutedEvent.RoutingStrategy"/>, <para/>
///     <see cref="RoutedEvent.HandlerType"/> and <para/>
///     <para/>
///
///     NOTE: None of the members can be null
/// </remarks>
/// <ExternalAPI/>
public sealed class RoutedEvent
{
    private string _name;
    private RoutingStrategy _routingStrategy;
    private Type _handlerType;
    private int _globalIndex;

    // Constructor for a RoutedEvent (is internal to the EventManager and is onvoked when a new
    // RoutedEvent is registered)
    internal RoutedEvent(
        string name,
        RoutingStrategy routingStrategy,
        Type handlerType)
    {
        _name = name;
        _routingStrategy = routingStrategy;
        _handlerType = handlerType;

        _globalIndex = GlobalEventManager.GetNextAvailableGlobalIndex(this);
    }

    /// <summary>
    ///     Returns the Name of the RoutedEvent
    /// </summary>
    /// <remarks>
    ///     RoutedEvent Name is unique within the 
    ///     OwnerType (super class types not considered 
    ///     when talking about uniqueness)
    /// </remarks>
    /// <ExternalAPI/>
    public string Name => _name;

    /// <summary>
    ///     Returns the <see cref="RoutingStrategy"/> 
    ///     of the RoutedEvent
    /// </summary>
    /// <ExternalAPI/>
    public RoutingStrategy RoutingStrategy => _routingStrategy;

    /// <summary>
    ///     Returns Type of Handler for the RoutedEvent
    /// </summary>
    /// <remarks>
    ///     HandlerType is a type of delegate
    /// </remarks>
    /// <ExternalAPI/>
    public Type HandlerType => _handlerType;

    // Check to see if the given delegate is a legal handler for this type.
    //  It either needs to be a type that the registering class knows how to
    //  handle, or a RoutedEventHandler which we can handle without the help
    //  of the registering class.
    internal bool IsLegalHandler( Delegate handler )
    {
        Type handlerType = handler.GetType();
        
        return ( (handlerType == HandlerType) ||
                 (handlerType == typeof(RoutedEventHandler) ) );
    }

    /// <summary>
    ///    String representation
    /// </summary>
    public override string ToString() => _name;

    /// <summary>
    ///    Index in GlobalEventManager 
    /// </summary>
    internal int GlobalIndex => _globalIndex;
}
