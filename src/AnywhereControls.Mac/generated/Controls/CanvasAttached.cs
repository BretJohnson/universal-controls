// This file is generated from ICanvas.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Mac.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft((StandardUIElement) element);
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft((StandardUIElement) element, value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop((StandardUIElement) element);
        public void SetTop(IUIElement element, double value) => Canvas.SetTop((StandardUIElement) element, value);
    }
}
