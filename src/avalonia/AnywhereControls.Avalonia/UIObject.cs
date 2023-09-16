using Avalonia;

namespace AnywhereControls.Avalonia;

/// <summary>
/// This is the base for predefined dependency objects
/// </summary>
public class UIObject : AvaloniaObject, IUIObject
{
    object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
    void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
    void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);
}
