namespace AnywhereControls.Avalonia;

public sealed class UICollection<T> : BasicUICollection<T>
{
    global::Avalonia.AvaloniaObject _parent;

    public UICollection(global::Avalonia.AvaloniaObject parent)
    {
        _parent = parent;
    }
}
