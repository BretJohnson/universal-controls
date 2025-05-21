namespace UniversalUI.Input;

public interface IHandleableRoutedEventArgs : IRoutedEventArgs
{
    public bool Handled { get; set; }
}
