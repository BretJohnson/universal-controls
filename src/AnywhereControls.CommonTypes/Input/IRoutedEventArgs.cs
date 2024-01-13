using System;

namespace AnywhereControls.Input;

public interface IRoutedEventArgs
{
    public object HostFrameworkEventArgs { get; }

    public void InvokeEventHandler(Delegate genericHandler, object genericTarget);
}

/// <summary>
///     Event handler for routed events.
/// </summary>
public delegate void RoutedEventHandler(object sender, IRoutedEventArgs e);
