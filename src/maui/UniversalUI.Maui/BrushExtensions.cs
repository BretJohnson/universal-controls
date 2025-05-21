using System;
using UniversalUI.Media;

namespace UniversalUI.Maui
{
    public static class BrushExtensions
    {
        public static Microsoft.Maui.Graphics.Color? ToMauiColor(this IBrush? brush)
        {
            if (brush is null)
                return null;
            else if (brush is ISolidColorBrush solidColorBrush)
                return solidColorBrush.Color.ToMauiColor();
            else throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
        }

        public static Microsoft.Maui.Graphics.Paint? ToMauiBrush(this IBrush? brush)
        {
            if (brush is null)
                return null;
            else if (brush is ISolidColorBrush solidColorBrush)
                return new Microsoft.Maui.Graphics.SolidPaint(solidColorBrush.Color.ToMauiColor());
            else if (brush is IGradientBrush gradientBrush)
            {
                // TODO: Complete this
                throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
            }
            else throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
        }
    }
}