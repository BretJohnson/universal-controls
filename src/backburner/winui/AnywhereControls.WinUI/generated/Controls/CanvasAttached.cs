// This file is generated from ICanvas.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.WinUI.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft(element.ToFrameworkElement());
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft(element.ToFrameworkElement(), value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop(element.ToFrameworkElement());
        public void SetTop(IUIElement element, double value) => Canvas.SetTop(element.ToFrameworkElement(), value);
    }
}
