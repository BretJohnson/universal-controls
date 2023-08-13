using System;

namespace Microsoft.StandardUI.WinUI
{
    public static class UIElementExtensions
    {
        public static Microsoft.UI.Xaml.FrameworkElement ToFrameworkElement(this IUIElement standardUIElement)
        {
            if (standardUIElement is Microsoft.UI.Xaml.FrameworkElement frameworkElement)
                return frameworkElement;

#if LATER
            if (standardUIElement is NativeUIElement nativeUIElement)
                return nativeUIElement.FrameworkElement;
#endif

            throw new InvalidOperationException($"UIElement is of unexpected type '{standardUIElement.GetType()}' and can't be converted to a native WinUI FrameworkElement");
        }
    }
}
