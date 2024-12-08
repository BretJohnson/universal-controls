using System.Windows;

namespace AnywhereUI.Wpf
{
    /// <summary>
    /// This is the base for predefined Anywhere Controls UI objects
    /// </summary>
    public class UIObject : DependencyObject, IUIObject
    {
        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);
    }
}
