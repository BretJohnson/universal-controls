using AnywhereUI.Media;

namespace AnywhereControlsAvalonia
{
    public static class BrushExtensions
    {
        public static Avalonia.Media.Brush? ToAvaloniaBrush(this IBrush? brush)
        {
            if (brush is null)
                return null;
            else if (brush is ISolidColorBrush solidColorBrush)
                return new Avalonia.Media.SolidColorBrush(solidColorBrush.Color.ToAvaloniaColor());
            else if (brush is IGradientBrush gradientBrush)
            {
                // TODO: Complete this
                throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
            }
            else throw new InvalidOperationException($"Brush type {brush.GetType()} isn't currently supported");
        }
    }
}
