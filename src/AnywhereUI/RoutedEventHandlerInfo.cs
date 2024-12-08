// This was adapted from the WPF source here: https://github.com/dotnet/wpf/blob/137b671131455a5c252a297747725ddce5a21c63/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/RoutedEventHandlerInfo.cs

using System;
using AnywhereUI.Input;

namespace AnywhereUI;

/// <summary>
///     Container for handler instance and other invocation preferences for this handler instance
/// </summary>
/// <remarks>
///     RoutedEventHandlerInfo constitutes the handler instance and flag that indicates if or not
///     this handler must be invoked for already handled events <para/>
///     <para/>
///
///     This class needs to be public because it is used by ContentElement in the Framework 
///     to store Instance EventHandlers
/// </remarks>
public readonly struct RoutedEventHandlerInfo
{
    private readonly Delegate _handler;
    private readonly bool _handledEventsToo;

    /// <summary>
    ///     Construtor for RoutedEventHandlerInfo
    /// </summary>
    /// <param name="handler">
    ///     Non-null handler
    /// </param>
    /// <param name="handledEventsToo">
    ///     Flag that indicates if or not the handler must 
    ///     be invoked for already handled events
    /// </param>
    internal RoutedEventHandlerInfo(Delegate handler, bool handledEventsToo)
    {
        _handler = handler;
        _handledEventsToo = handledEventsToo;
    }

    internal RoutedEventHandlerInfo(Delegate handler)
    {
        _handler = handler;
    }

    /// <summary>
    ///     Returns associated handler instance
    /// </summary>
    public Delegate Handler => _handler;

    /// <summary>
    ///     Returns HandledEventsToo Flag
    /// </summary>
    public bool InvokeHandledEventsToo => _handledEventsToo;

    // Invokes handler instance as per specified invocation preferences
    internal void InvokeNonhandleableEventHander(object target, IRoutedEventArgs routedEventArgs)
    {
        if (_handler is RoutedEventHandler routedEventHandler)
        {
            // Generic RoutedEventHandler is called directly here since we don't need the InvokeEventHandler
            // override to cast to the proper type - we know what it is.
            routedEventHandler(target, routedEventArgs);
        }
        else
        {
            routedEventArgs.InvokeEventHandler(_handler, target);
        }
    }

    internal void InvokeHandleableEventHandler(object target, IHandleableRoutedEventArgs handleableRoutedEventArgs)
    {
        if (!handleableRoutedEventArgs.Handled || _handledEventsToo)
        {
            if (_handler is RoutedEventHandler routedEventHandler)
            {
                // Generic RoutedEventHandler is called directly here since we don't need the InvokeEventHandler
                // override to cast to the proper type - we know what it is.
                routedEventHandler(target, handleableRoutedEventArgs);
            }
            else
            {
                handleableRoutedEventArgs.InvokeEventHandler(_handler, target);
            }
        }
    }

    /// <summary>
    ///     Is the given object equivalent to the current one
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj == null || obj is not RoutedEventHandlerInfo routedEventHandlerInfoObj)
            return false;

        return Equals(routedEventHandlerInfoObj);
    }

    /// <summary>
    ///     Is the given RoutedEventHandlerInfo equals the current
    /// </summary>
    public bool Equals(RoutedEventHandlerInfo handlerInfo) =>
        _handler == handlerInfo._handler && _handledEventsToo == handlerInfo._handledEventsToo;

    /// <summary>
    ///     Serves as a hash function for a particular type, suitable for use in 
    ///     hashing algorithms and data structures like a hash table
    /// </summary>
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    ///     Equals operator overload
    /// </summary>
    public static bool operator ==(RoutedEventHandlerInfo handlerInfo1, RoutedEventHandlerInfo handlerInfo2) =>
        handlerInfo1.Equals(handlerInfo2);

    /// <summary>
    ///     NotEquals operator overload
    /// </summary>
    public static bool operator !=(RoutedEventHandlerInfo handlerInfo1, RoutedEventHandlerInfo handlerInfo2) =>
        !handlerInfo1.Equals(handlerInfo2);
}