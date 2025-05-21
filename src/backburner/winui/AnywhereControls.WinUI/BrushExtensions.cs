using System;
using UniversalUI.Media;
using Microsoft.UI.Composition;

namespace AnywhereControls.WinUI
{
    public static class BrushExtensions
    {
        public static CompositionBrush? ToCompositionBrush(this IBrush? brush, Compositor compositor)
        {
            if (brush is null)
                return null;
            else if (brush is ISolidColorBrush solidColorBrush)
                return compositor.CreateColorBrush(solidColorBrush.Color.ToWinUIColor());
            else if (brush is IGradientBrush gradientBrush)
            {
                // TODO: Complete this
                throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
            }
            else throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
        }
    }
}
