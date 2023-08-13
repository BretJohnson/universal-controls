using Foundation;

namespace Microsoft.StandardUI.Mac
{
    public class StandardUIObject : NSObject, IUIObject
    {
        private BasicUIProperties _properties = new BasicUIProperties(true);

        public object? GetValue(BasicUIProperty property) => _properties.GetValue(property);
        object? IUIObject.GetValue(IUIProperty property) => _properties.GetValue((BasicUIProperty)property);

        public object? ReadLocalValue(BasicUIProperty property) => _properties.ReadLocalValue(property);
        object? IUIObject.ReadLocalValue(IUIProperty property) => _properties.ReadLocalValue((BasicUIProperty)property);

        public void SetValue(BasicUIProperty property, object? value) => _properties.SetValue(property, value);
        void IUIObject.SetValue(IUIProperty property, object? value) => _properties.SetValue((BasicUIProperty)property, value);

        public void ClearValue(BasicUIProperty property) => _properties.ClearValue(property);
        void IUIObject.ClearValue(IUIProperty property) => _properties.ClearValue((BasicUIProperty)property);
    }
}
