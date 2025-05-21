using UniversalUI.DefaultImplementations;

namespace AnywhereControls.WinForms
{
    public class StandardUIObject : IUIObject
    {
        private PropertyValues _propertyValues = new PropertyValues(true);

        public object? GetValue(UIProperty property) => _propertyValues.GetValue(property);
        object? IUIObject.GetValue(IUIProperty property) => _propertyValues.GetValue((UIProperty)property);

        public object? ReadLocalValue(UIProperty property) => _propertyValues.ReadLocalValue(property);
        object? IUIObject.ReadLocalValue(IUIProperty property) => _propertyValues.ReadLocalValue((UIProperty)property);

        public void SetValue(UIProperty property, object? value) => _propertyValues.SetValue(property, value);
        void IUIObject.SetValue(IUIProperty property, object? value) => _propertyValues.SetValue((UIProperty)property, value);

        public void ClearValue(UIProperty property) => _propertyValues.ClearValue(property);
        void IUIObject.ClearValue(IUIProperty property) => _propertyValues.ClearValue((UIProperty)property);
    }
}
