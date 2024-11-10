using System.ComponentModel;

namespace AnywhereControls.Controls
{
    [UIModelObject]
    public interface ICanvasAttached
    {
        [DefaultValue(0.0)]
        double GetLeft(IUIElement element);
        void SetLeft(IUIElement element, double length);

        [DefaultValue(0.0)]
        double GetTop(IUIElement element);
        void SetTop(IUIElement element, double length);
    }
}
