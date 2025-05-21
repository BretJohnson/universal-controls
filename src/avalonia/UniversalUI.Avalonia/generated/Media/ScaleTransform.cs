// This file is generated from IScaleTransform.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class ScaleTransform : Transform, IScaleTransform
    {
        public static readonly Avalonia.StyledProperty<double> CenterXProperty = AvaloniaProperty.Register<ScaleTransform, double>(nameof(CenterX), 0.0);
        public static readonly Avalonia.StyledProperty<double> CenterYProperty = AvaloniaProperty.Register<ScaleTransform, double>(nameof(CenterY), 0.0);
        public static readonly Avalonia.StyledProperty<double> ScaleXProperty = AvaloniaProperty.Register<ScaleTransform, double>(nameof(ScaleX), 1.0);
        public static readonly Avalonia.StyledProperty<double> ScaleYProperty = AvaloniaProperty.Register<ScaleTransform, double>(nameof(ScaleY), 1.0);
        
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
        
        public double ScaleX
        {
            get => (double) GetValue(ScaleXProperty);
            set => SetValue(ScaleXProperty, value);
        }
        
        public double ScaleY
        {
            get => (double) GetValue(ScaleYProperty);
            set => SetValue(ScaleYProperty, value);
        }
    }
}
