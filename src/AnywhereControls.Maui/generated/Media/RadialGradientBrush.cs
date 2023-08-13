// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using AnywhereControls.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Media
{
    public class RadialGradientBrush : GradientBrush, IRadialGradientBrush
    {
        public static readonly BindableProperty CenterProperty = PropertyUtils.Register(nameof(Center), typeof(PointMaui), typeof(RadialGradientBrush), new PointMaui(0.5, 0.5));
        public static readonly BindableProperty GradientOriginProperty = PropertyUtils.Register(nameof(GradientOrigin), typeof(PointMaui), typeof(RadialGradientBrush), new PointMaui(0.5, 0.5));
        public static readonly BindableProperty RadiusXProperty = PropertyUtils.Register(nameof(RadiusX), typeof(double), typeof(RadialGradientBrush), 0.5);
        
        public PointMaui Center
        {
            get => (PointMaui) GetValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }
        Point IRadialGradientBrush.Center
        {
            get => Center.Point;
            set => Center = new PointMaui(value);
        }
        
        public PointMaui GradientOrigin
        {
            get => (PointMaui) GetValue(GradientOriginProperty);
            set => SetValue(GradientOriginProperty, value);
        }
        Point IRadialGradientBrush.GradientOrigin
        {
            get => GradientOrigin.Point;
            set => GradientOrigin = new PointMaui(value);
        }
        
        public double RadiusX
        {
            get => (double) GetValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
    }
}
