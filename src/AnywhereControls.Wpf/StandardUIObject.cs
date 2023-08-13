using System.Windows;

namespace Microsoft.StandardUI.Wpf
{
    /// <summary>
    /// This is the base for predefined dependency objects
    /// </summary>
    public class StandardUIObject : DependencyObject, IUIObject
    {
        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
        object? IUIObject.ReadLocalValue(IUIProperty property) => ReadLocalValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);
    }
}
