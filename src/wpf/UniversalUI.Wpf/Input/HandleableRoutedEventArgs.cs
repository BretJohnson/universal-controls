using System;
using UniversalUI.Input;

namespace UniversalUI.Wpf.Input;

internal abstract class HandleableRoutedEventArgs<THostFrameworkEventArgs> : IHandleableRoutedEventArgs where THostFrameworkEventArgs : System.Windows.RoutedEventArgs
{
    protected THostFrameworkEventArgs _hostFrameworkEventArgs;

    public HandleableRoutedEventArgs(THostFrameworkEventArgs hostFrameworkEventArgs)
    {
        _hostFrameworkEventArgs = hostFrameworkEventArgs;
    }

    public object HostFrameworkEventArgs => _hostFrameworkEventArgs;

    bool IHandleableRoutedEventArgs.Handled {
        get => _hostFrameworkEventArgs.Handled;
        set => _hostFrameworkEventArgs.Handled = value;
    }

    public abstract void InvokeEventHandler(Delegate genericHandler, object genericTarget);
}
