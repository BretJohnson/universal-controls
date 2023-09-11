// This file is generated from IGradientStop.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class GradientStop : StandardUIObject, IGradientStop
    {
        public static readonly DependencyProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(GradientStop), Colors.Transparent);
        public static readonly DependencyProperty OffsetProperty = PropertyUtils.Register(nameof(Offset), typeof(double), typeof(GradientStop), 0.0);
        
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
