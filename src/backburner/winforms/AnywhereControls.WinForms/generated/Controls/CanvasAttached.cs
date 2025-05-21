// This file is generated from ICanvas.cs. Update the source file to change its contents.

using UniversalUI.Controls;

namespace AnywhereControls.WinForms.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft((System.Windows.Forms.Control) element);
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft((System.Windows.Forms.Control) element, value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop((System.Windows.Forms.Control) element);
        public void SetTop(IUIElement element, double value) => Canvas.SetTop((System.Windows.Forms.Control) element, value);
    }
}
