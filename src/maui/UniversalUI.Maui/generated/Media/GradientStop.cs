// This file is generated from IGradientStop.cs. Update the source file to change its contents.

using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;
using Colors = AnywhereControls.Colors;
using Color = AnywhereControls.Color;

namespace UniversalUI.Maui.Media
{
    public class GradientStop : UIObject, IGradientStop
    {
        public static readonly BindableProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(GradientStop), Colors.Transparent);
        public static readonly BindableProperty OffsetProperty = PropertyUtils.Register(nameof(Offset), typeof(double), typeof(GradientStop), 0.0);
        
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
