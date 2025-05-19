namespace AnywhereUI.Input;

public interface IPointerEventArgs : IHandleableRoutedEventArgs
{
}

public delegate void PointerEventHandler(object sender, IPointerEventArgs e);
