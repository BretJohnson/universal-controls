using System;
using Microsoft.Maui.Controls;

namespace AnywhereUI.Maui
{
    /// <summary>
    /// This is the base for predefined non-view bindable objects
    /// </summary>
    public class UIObject : BindableObject, IUIObject
    {
        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).BindableProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).BindableProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).BindableProperty);
    }
}
