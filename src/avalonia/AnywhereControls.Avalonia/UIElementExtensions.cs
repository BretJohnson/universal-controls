using Avalonia.Controls;

namespace AnywhereControls.Avalonia
{
    public static class UIElementExtensions
    {
        public static Control ToAvaloniaControl(this IUIElement uiElement)
        {
            if (uiElement is Control control)
                return control;

            if (uiElement is WrappedNativeUIElement nativeUIElement)
                return nativeUIElement.Control;

            throw new InvalidOperationException($"UIElement is of unexpected type '{uiElement.GetType()}' and can't be converted to a native WPF UIElement");
        }
    }
}
