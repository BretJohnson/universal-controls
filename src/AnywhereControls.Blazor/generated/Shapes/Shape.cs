// This file is generated from IShape.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Blazor.Media;
using Microsoft.AspNetCore.Components;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI.Blazor.Shapes
{
    public class Shape : BuiltInUIElement, IShape
    {
        public static readonly UIProperty FillProperty = new UIProperty(nameof(Fill), null);
        public static readonly UIProperty StrokeProperty = new UIProperty(nameof(Stroke), null);
        public static readonly UIProperty StrokeThicknessProperty = new UIProperty(nameof(StrokeThickness), 1.0);
        public static readonly UIProperty StrokeMiterLimitProperty = new UIProperty(nameof(StrokeMiterLimit), 10.0);
        public static readonly UIProperty StrokeLineCapProperty = new UIProperty(nameof(StrokeLineCap), PenLineCap.Flat);
        public static readonly UIProperty StrokeLineJoinProperty = new UIProperty(nameof(StrokeLineJoin), PenLineJoin.Miter);
        
        [Parameter]
        public IBrush? Fill
        {
            get => (Brush?) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
        
        [Parameter]
        public IBrush? Stroke
        {
            get => (Brush?) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        
        [Parameter]
        public double StrokeThickness
        {
            get => (double) GetNonNullValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
        
        [Parameter]
        public double StrokeMiterLimit
        {
            get => (double) GetNonNullValue(StrokeMiterLimitProperty);
            set => SetValue(StrokeMiterLimitProperty, value);
        }
        
        [Parameter]
        public PenLineCap StrokeLineCap
        {
            get => (PenLineCap) GetNonNullValue(StrokeLineCapProperty);
            set => SetValue(StrokeLineCapProperty, value);
        }
        
        [Parameter]
        public PenLineJoin StrokeLineJoin
        {
            get => (PenLineJoin) GetNonNullValue(StrokeLineJoinProperty);
            set => SetValue(StrokeLineJoinProperty, value);
        }
    }
}
