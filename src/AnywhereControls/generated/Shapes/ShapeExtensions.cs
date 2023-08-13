// This file is generated from IShape.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Shapes
{
    public static class ShapeExtensions
    {
        public static T Fill<T>(this T shape, IBrush? value) where T : IShape
        {
            shape.Fill = value;
            return shape;
        }
        
        public static T Stroke<T>(this T shape, IBrush? value) where T : IShape
        {
            shape.Stroke = value;
            return shape;
        }
        
        public static T StrokeThickness<T>(this T shape, double value) where T : IShape
        {
            shape.StrokeThickness = value;
            return shape;
        }
        
        public static T StrokeMiterLimit<T>(this T shape, double value) where T : IShape
        {
            shape.StrokeMiterLimit = value;
            return shape;
        }
        
        public static T StrokeLineCap<T>(this T shape, PenLineCap value) where T : IShape
        {
            shape.StrokeLineCap = value;
            return shape;
        }
        
        public static T StrokeLineJoin<T>(this T shape, PenLineJoin value) where T : IShape
        {
            shape.StrokeLineJoin = value;
            return shape;
        }
    }
}
