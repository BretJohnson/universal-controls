// This file is generated from IGradientStop.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class GradientStop : UIObject, IGradientStop
    {
        public static readonly Avalonia.StyledProperty<Color> ColorProperty = AvaloniaProperty.Register<GradientStop, Color>(nameof(Color), Colors.Transparent);
        public static readonly Avalonia.StyledProperty<double> OffsetProperty = AvaloniaProperty.Register<GradientStop, double>(nameof(Offset), 0.0);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        
        public double Offset
        {
            get => (double) GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }
    }
}
