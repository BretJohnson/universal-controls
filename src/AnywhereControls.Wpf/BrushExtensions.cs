using System;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Wpf
{
    public static class BrushExtensions
    {
        public static System.Windows.Media.Brush? ToWpfBrush(this IBrush? brush)
        {
            if (brush is null)
                return null;
            else if (brush is ISolidColorBrush solidColorBrush)
                return new System.Windows.Media.SolidColorBrush(solidColorBrush.Color.ToWpfColor());
            else if (brush is IGradientBrush gradientBrush)
            {
                // TODO: Complete this
                throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
            }
            else throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
        }
    }
}
