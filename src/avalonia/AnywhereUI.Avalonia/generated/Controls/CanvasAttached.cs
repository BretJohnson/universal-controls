// This file is generated from ICanvas.cs. Update the source file to change its contents.

using AnywhereUI.Controls;
using AnywhereUI;

namespace AnywhereControlsAvalonia.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft(element.ToAvaloniaControl());
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft(element.ToAvaloniaControl(), value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop(element.ToAvaloniaControl());
        public void SetTop(IUIElement element, double value) => Canvas.SetTop(element.ToAvaloniaControl(), value);
    }
}
