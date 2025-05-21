using UniversalUI;
using Avalonia;

namespace AnywhereControlsAvalonia
{
    public class UIProperty : IUIProperty
    {
        public AvaloniaProperty AvaloniaProperty { get; }

        public UIProperty(AvaloniaProperty property)
        {
            AvaloniaProperty = property;
        }

        public static AvaloniaProperty GetDependencyProperty(IUIProperty property) =>
            ((UIProperty)property).AvaloniaProperty;
    }
}
