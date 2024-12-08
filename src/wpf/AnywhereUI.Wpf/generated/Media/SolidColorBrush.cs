// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereUI.Wpf.Media
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
