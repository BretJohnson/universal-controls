using AnywhereUI;
using Avalonia;

namespace AnywhereControlsAvalonia;

/// <summary>
/// This is the base for predefined Anywhere Controls UI objects
/// </summary>
public class UIObject : AvaloniaObject, IUIObject
{
    object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).AvaloniaProperty);
    void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).AvaloniaProperty, value);
    void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).AvaloniaProperty);
}
