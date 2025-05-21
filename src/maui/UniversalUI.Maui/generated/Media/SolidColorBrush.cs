// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;
using Colors = AnywhereControls.Colors;
using Color = AnywhereControls.Color;

namespace UniversalUI.Maui.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly BindableProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(SolidColorBrush), Colors.Transparent);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
