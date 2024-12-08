// This file is generated from ICanvas.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereControls.Blazor.Controls
{
    public class CanvasAttached : ICanvasAttached
    {
        public static CanvasAttached Instance = new CanvasAttached();
        
        public double GetLeft(IUIElement element) => Canvas.GetLeft((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetLeft(IUIElement element, double value) => Canvas.SetLeft((Microsoft.AspNetCore.Components.ComponentBase) element, value);
        
        public double GetTop(IUIElement element) => Canvas.GetTop((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetTop(IUIElement element, double value) => Canvas.SetTop((Microsoft.AspNetCore.Components.ComponentBase) element, value);
    }
}
