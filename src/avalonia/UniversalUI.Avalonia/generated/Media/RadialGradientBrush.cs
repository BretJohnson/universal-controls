// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class RadialGradientBrush : GradientBrush, IRadialGradientBrush
    {
        public static readonly Avalonia.StyledProperty<Point> CenterProperty = AvaloniaProperty.Register<RadialGradientBrush, Point>(nameof(Center), Point.CenterDefault);
        public static readonly Avalonia.StyledProperty<Point> GradientOriginProperty = AvaloniaProperty.Register<RadialGradientBrush, Point>(nameof(GradientOrigin), Point.CenterDefault);
        public static readonly Avalonia.StyledProperty<double> RadiusXProperty = AvaloniaProperty.Register<RadialGradientBrush, double>(nameof(RadiusX), 0.5);
        
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
