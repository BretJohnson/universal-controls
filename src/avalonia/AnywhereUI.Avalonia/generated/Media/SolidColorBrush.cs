// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly Avalonia.StyledProperty<Color> ColorProperty = AvaloniaProperty.Register<SolidColorBrush, Color>(nameof(Color), Colors.Transparent);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
