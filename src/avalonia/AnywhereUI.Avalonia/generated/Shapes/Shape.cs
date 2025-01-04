// This file is generated from IShape.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using AnywhereUIAvalonia.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Shapes
{
    public class Shape : BuiltInUIElement, IShape
    {
        public static readonly Avalonia.StyledProperty<Brush?> FillProperty = AvaloniaProperty.Register<Shape, Brush?>(nameof(Fill), null);
        public static readonly Avalonia.StyledProperty<Brush?> StrokeProperty = AvaloniaProperty.Register<Shape, Brush?>(nameof(Stroke), null);
        public static readonly Avalonia.StyledProperty<double> StrokeThicknessProperty = AvaloniaProperty.Register<Shape, double>(nameof(StrokeThickness), 1.0);
        public static readonly Avalonia.StyledProperty<double> StrokeMiterLimitProperty = AvaloniaProperty.Register<Shape, double>(nameof(StrokeMiterLimit), 10.0);
        public static readonly Avalonia.StyledProperty<PenLineCap> StrokeLineCapProperty = AvaloniaProperty.Register<Shape, PenLineCap>(nameof(StrokeLineCap), PenLineCap.Flat);
        public static readonly Avalonia.StyledProperty<PenLineJoin> StrokeLineJoinProperty = AvaloniaProperty.Register<Shape, PenLineJoin>(nameof(StrokeLineJoin), PenLineJoin.Miter);
        
        public Brush? Fill
        {
            get => (Brush?) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
        IBrush? IShape.Fill
        {
            get => Fill;
            set => Fill = (Brush?) value;
        }
        
        public Brush? Stroke
        {
            get => (Brush?) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        IBrush? IShape.Stroke
        {
            get => Stroke;
            set => Stroke = (Brush?) value;
        }
        
        public double StrokeThickness
        {
            get => (double) GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
        
        public double StrokeMiterLimit
        {
            get => (double) GetValue(StrokeMiterLimitProperty);
            set => SetValue(StrokeMiterLimitProperty, value);
        }
        
        public PenLineCap StrokeLineCap
        {
            get => (PenLineCap) GetValue(StrokeLineCapProperty);
            set => SetValue(StrokeLineCapProperty, value);
        }
        
        public PenLineJoin StrokeLineJoin
        {
            get => (PenLineJoin) GetValue(StrokeLineJoinProperty);
            set => SetValue(StrokeLineJoinProperty, value);
        }
    }
}
