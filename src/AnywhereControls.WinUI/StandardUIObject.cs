using Microsoft.UI.Xaml;

namespace AnywhereControls.WinUI
{
    /// <summary>
    /// This is the base for predefined dependency objects
    /// </summary>
    public class StandardUIObject : DependencyObject, IUIObject
    {
        public void ClearValue(IUIProperty property)
        {
            DependencyProperty dependencyProperty = ((UIProperty)property).DependencyProperty;
            ClearValue(dependencyProperty);
        }

        public object GetValue(IUIProperty property)
        {
            DependencyProperty dependencyProperty = ((UIProperty)property).DependencyProperty;
            return GetValue(dependencyProperty);
        }

        public object ReadLocalValue(IUIProperty property)
        {
            DependencyProperty dependencyProperty = ((UIProperty)property).DependencyProperty;
            return ReadLocalValue(dependencyProperty);
        }

        public void SetValue(IUIProperty property, object? value)
        {
            DependencyProperty dependencyProperty = ((UIProperty)property).DependencyProperty;
            SetValue(dependencyProperty, value);
        }
    }
}
