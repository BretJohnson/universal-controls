// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Media
{
    public class RadialGradientBrush : GradientBrush, IRadialGradientBrush
    {
        public static readonly DependencyProperty CenterProperty = PropertyUtils.Register(nameof(Center), typeof(PointWinUI), typeof(RadialGradientBrush), new PointWinUI(0.5, 0.5));
        public static readonly DependencyProperty GradientOriginProperty = PropertyUtils.Register(nameof(GradientOrigin), typeof(PointWinUI), typeof(RadialGradientBrush), new PointWinUI(0.5, 0.5));
        public static readonly DependencyProperty RadiusXProperty = PropertyUtils.Register(nameof(RadiusX), typeof(double), typeof(RadialGradientBrush), 0.5);
        
        public PointWinUI Center
        {
            get => (PointWinUI) GetValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }
        Point IRadialGradientBrush.Center
        {
            get => Center.Point;
            set => Center = new PointWinUI(value);
        }
        
        public PointWinUI GradientOrigin
        {
            get => (PointWinUI) GetValue(GradientOriginProperty);
            set => SetValue(GradientOriginProperty, value);
        }
        Point IRadialGradientBrush.GradientOrigin
        {
            get => GradientOrigin.Point;
            set => GradientOrigin = new PointWinUI(value);
        }
        
        public double RadiusX
        {
            get => (double) GetValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
    }
}
