// This file is generated from IShape.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using AnywhereUI.Mac.Media;
using AnywhereUI.Shapes;

namespace AnywhereControls.Mac.Shapes
{
    public class Shape : BuiltInUIElement, IShape
    {
        public static readonly UIProperty FillProperty = new UIProperty(nameof(Fill), null);
        public static readonly UIProperty StrokeProperty = new UIProperty(nameof(Stroke), null);
        public static readonly UIProperty StrokeThicknessProperty = new UIProperty(nameof(StrokeThickness), 1.0);
        public static readonly UIProperty StrokeMiterLimitProperty = new UIProperty(nameof(StrokeMiterLimit), 10.0);
        public static readonly UIProperty StrokeLineCapProperty = new UIProperty(nameof(StrokeLineCap), PenLineCap.Flat);
        public static readonly UIProperty StrokeLineJoinProperty = new UIProperty(nameof(StrokeLineJoin), PenLineJoin.Miter);
        
        public IBrush? Fill
        {
            get => (Brush?) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
        
        public IBrush? Stroke
        {
            get => (Brush?) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        
        public double StrokeThickness
        {
            get => (double) GetNonNullValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
        
        public double StrokeMiterLimit
        {
            get => (double) GetNonNullValue(StrokeMiterLimitProperty);
            set => SetValue(StrokeMiterLimitProperty, value);
        }
        
        public PenLineCap StrokeLineCap
        {
            get => (PenLineCap) GetNonNullValue(StrokeLineCapProperty);
            set => SetValue(StrokeLineCapProperty, value);
        }
        
        public PenLineJoin StrokeLineJoin
        {
            get => (PenLineJoin) GetNonNullValue(StrokeLineJoinProperty);
            set => SetValue(StrokeLineJoinProperty, value);
        }
    }
}
