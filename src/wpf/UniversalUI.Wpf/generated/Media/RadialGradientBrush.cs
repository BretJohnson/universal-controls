// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using UniversalUI.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf.Media
{
    public class RadialGradientBrush : GradientBrush, IRadialGradientBrush
    {
        public static readonly DependencyProperty CenterProperty = PropertyUtils.Register(nameof(Center), typeof(Point), typeof(RadialGradientBrush), Point.CenterDefault);
        public static readonly DependencyProperty GradientOriginProperty = PropertyUtils.Register(nameof(GradientOrigin), typeof(Point), typeof(RadialGradientBrush), Point.CenterDefault);
        public static readonly DependencyProperty RadiusXProperty = PropertyUtils.Register(nameof(RadiusX), typeof(double), typeof(RadialGradientBrush), 0.5);
        
        public Point Center
        {
            get => (Point) GetValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }
        
        public Point GradientOrigin
        {
            get => (Point) GetValue(GradientOriginProperty);
            set => SetValue(GradientOriginProperty, value);
        }
        
        public double RadiusX
        {
            get => (double) GetValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
    }
}
