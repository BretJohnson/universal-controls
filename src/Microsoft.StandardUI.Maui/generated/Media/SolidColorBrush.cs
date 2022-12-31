// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace Microsoft.StandardUI.Maui.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly BindableProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(SolidColorBrush), null);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
