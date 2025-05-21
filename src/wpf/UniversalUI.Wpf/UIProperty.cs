using System.Windows;

namespace UniversalUI.Wpf
{
    public class UIProperty : IUIProperty
    {
        public DependencyProperty DependencyProperty { get; }

        public UIProperty(DependencyProperty property)
        {
            DependencyProperty = property;
        }

        public static DependencyProperty GetDependencyProperty(IUIProperty property) =>
            ((UIProperty)property).DependencyProperty;
    }
}
