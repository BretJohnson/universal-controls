// This file is generated from ICanvas.cs. Update the source file to change its contents.

using System;

namespace AnywhereControls.Controls
{
    public static class CanvasExtensions
    {
        private static readonly Lazy<ICanvasAttached> s_CanvasAttached = new Lazy<ICanvasAttached>(() => HostEnvironment.Factory.CanvasAttachedInstance);
        public static ICanvasAttached CanvasAttachedInstance => s_CanvasAttached.Value;
        
        // Attached properties
        
        public static double CanvasLeft<T>(this T uiElement) where T : IUIElement => CanvasAttachedInstance.GetLeft(uiElement);
        public static T CanvasLeft<T>(this T uiElement, double value) where T : IUIElement
        {
            CanvasAttachedInstance.SetLeft(uiElement, value);
            return uiElement;
        }
        
        public static double CanvasTop<T>(this T uiElement) where T : IUIElement => CanvasAttachedInstance.GetTop(uiElement);
        public static T CanvasTop<T>(this T uiElement, double value) where T : IUIElement
        {
            CanvasAttachedInstance.SetTop(uiElement, value);
            return uiElement;
        }
    }
}
