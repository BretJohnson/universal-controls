// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using CommonUI;
using AnywhereControls.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly DependencyProperty ColorProperty = PropertyUtils.Register(nameof(Color), typeof(Color), typeof(SolidColorBrush), null);
        
        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}
