using Microsoft.Maui.Controls;

namespace UniversalUI.Maui
{
    public class UIProperty : IUIProperty
    {
        public BindableProperty BindableProperty { get; }

        public UIProperty(BindableProperty property)
        {
            BindableProperty = property;
        }

        public static BindableProperty GetBindableProperty(IUIProperty property) =>
            ((UIProperty)property).BindableProperty;
    }
}
