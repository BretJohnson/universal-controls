// This file is generated from IRotateTransform.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class RotateTransform : Transform, IRotateTransform
    {
        public static readonly Avalonia.StyledProperty<double> AngleProperty = AvaloniaProperty.Register<RotateTransform, double>(nameof(Angle), 0.0);
        public static readonly Avalonia.StyledProperty<double> CenterXProperty = AvaloniaProperty.Register<RotateTransform, double>(nameof(CenterX), 0.0);
        public static readonly Avalonia.StyledProperty<double> CenterYProperty = AvaloniaProperty.Register<RotateTransform, double>(nameof(CenterY), 0.0);
        
        public double Angle
        {
            get => (double) GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }
        
        public double CenterX
        {
            get => (double) GetValue(CenterXProperty);
            set => SetValue(CenterXProperty, value);
        }
        
        public double CenterY
        {
            get => (double) GetValue(CenterYProperty);
            set => SetValue(CenterYProperty, value);
        }
    }
}
