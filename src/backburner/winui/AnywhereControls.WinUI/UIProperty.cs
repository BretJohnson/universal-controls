using Microsoft.UI.Xaml;

namespace AnywhereControls.WinUI
{
    public class UIProperty : IUIProperty
    {
        public DependencyProperty DependencyProperty { get; }

        public UIProperty(DependencyProperty property)
        {
            DependencyProperty = property;
        }

        public static DependencyProperty GetDependencyProeprty(IUIProperty property)
        {
            return ((UIProperty)property).DependencyProperty;
        }
    }
}
