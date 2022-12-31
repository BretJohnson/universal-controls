// This file is generated from IGradientStop.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Media
{
    public class GradientStop : StandardUIObject, IGradientStop
    {
        public static readonly DependencyProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(GradientStop), null);
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
