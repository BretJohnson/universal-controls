// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly DependencyProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(SolidColorBrush), Colors.Transparent);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
