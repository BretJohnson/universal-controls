// This file is generated from ICanvas.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Wpf.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft(element.ToWpfUIElement());
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft(element.ToWpfUIElement(), value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop(element.ToWpfUIElement());
        public void SetTop(IUIElement element, double value) => Canvas.SetTop(element.ToWpfUIElement(), value);
    }
}
