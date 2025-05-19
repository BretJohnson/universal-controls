namespace AnywhereUI.Input;

public interface IHandleableRoutedEventArgs : IRoutedEventArgs
{
    public bool Handled { get; set; }
}
