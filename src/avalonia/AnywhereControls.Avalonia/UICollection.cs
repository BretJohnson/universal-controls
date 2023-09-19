using AnywhereControls;

namespace AnywhereControlsAvalonia;

public sealed class UICollection<T> : BasicUICollection<T>
{
    Avalonia.AvaloniaObject _parent;

    public UICollection(Avalonia.AvaloniaObject parent)
    {
        _parent = parent;
    }
}
