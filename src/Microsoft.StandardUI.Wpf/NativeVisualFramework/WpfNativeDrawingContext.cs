using System;
using System.Globalization;
using System.Windows.Media;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Media.Wpf;
using Microsoft.StandardUI.Shapes;
using Microsoft.StandardUI.Wpf.Text;
using Pen = Microsoft.StandardUI.Media.Pen;

namespace Microsoft.StandardUI.Wpf.NativeVisualFramework
{
    public class WpfNativeDrawingContext : IDrawingContext
    {
        private DrawingGroup _drawingGroup;
        private DrawingContext? _drawingContext;

        public WpfNativeDrawingContext()
        {
            _drawingGroup = new DrawingGroup();
            _drawingContext = _drawingGroup.Open();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_drawingContext != null)
            {
                if (disposing)
                {
                    IDisposable disposable = _drawingContext;
                    disposable.Dispose();
                }

                _drawingContext = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DrawEllipse(IEllipse ellipse, double width, double height)
        {
            Brush? wpfBrush = ellipse.Fill.ToWpfBrush();
            System.Windows.Media.Pen? wpfPen = ToWpfNativePen(ellipse);

            double radiusX = width / 2;
            double radiusY = height / 2;
            var center = new System.Windows.Point(radiusX, radiusY);

            _drawingContext!.DrawEllipse(wpfBrush, wpfPen, center, radiusX, radiusY);
        }

        public void DrawLine(ILine line)
        {
            System.Windows.Media.Pen? wpfPen = ToWpfNativePen(line);
            if (wpfPen != null)
            {
                _drawingContext!.DrawLine(wpfPen,
                    new System.Windows.Point(line.X1, line.Y1),
                    new System.Windows.Point(line.X2, line.Y2));
            }
        }

        public void DrawPath(IPath path)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygon(IPolygon polygon)
        {
#if LATER
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polygon.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polygon.Points), close: true);

            DrawShapePath(skPath, polygon);
#endif
        }

        public void DrawPolyline(IPolyline polyline)
        {
#if LATER
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polyline.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polyline.Points), close: false);

            DrawShapePath(skPath, polyline);
#endif
        }

        public void DrawRectangle(IBrush? brush, Pen? pen, Rect rect)
        {
            System.Windows.Rect wpfRect = rect.ToWpfRect();
            Brush? wpfBurush = brush?.ToWpfBrush();
            System.Windows.Media.Pen? wpfPen = pen?.ToWpfPen();

            _drawingContext!.DrawRectangle(wpfBurush, wpfPen, wpfRect);
        }

        public void DrawRoundedRectangle(IBrush? brush, Pen? pen, Rect rect, double radiusX, double radiusY)
        {
            System.Windows.Rect wpfRect = rect.ToWpfRect();
            Brush? wpfBurush = brush?.ToWpfBrush();
            System.Windows.Media.Pen? wpfPen = pen?.ToWpfPen();

            _drawingContext!.DrawRoundedRectangle(wpfBurush, wpfPen, wpfRect, radiusX, radiusY);
        }

        public void DrawRectangle(IRectangle rectangle, double width, double height)
        {
            System.Windows.Rect wpfRect = new System.Windows.Rect(0, 0, width, height);

            Brush? wpfBurush = rectangle.Fill.ToWpfBrush();
            System.Windows.Media.Pen? wpfPen = ToWpfNativePen(rectangle);

            if (rectangle.RadiusX > 0 || rectangle.RadiusY > 0)
                _drawingContext!.DrawRoundedRectangle(wpfBurush, wpfPen, wpfRect, rectangle.RadiusX, rectangle.RadiusY);
            else
                _drawingContext!.DrawRectangle(wpfBurush, wpfPen, wpfRect);
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
            Brush? brush = textBlock.Foreground.ToWpfBrush();
            if (brush == null)
                return;

            var typeface = new Typeface(textBlock.FontFamily.ToWpfFontFamily(),
                textBlock.FontStyle.ToWpfFontStyle(),
                textBlock.FontWeight.ToWpfFontWeight(),
                textBlock.FontStretch.ToWpfFontStretch());

            // Create the initial formatted text string.
            FormattedText formattedText = new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToWpfFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush,
                1.0); // TODO: Set this appropriately

            _drawingContext!.DrawText(formattedText, new System.Windows.Point(0, 0));
        }

        public void PushRotateTransform(double angle, double centerX, double centerY)
        {
            var transform = new RotateTransform(
                angle: angle,
                centerX: centerX,
                centerY: centerY);
            _drawingContext!.PushTransform(transform);
        }

        public void PushTranslateTransform(double offsetX, double offsetY)
        {
            var transform = new TranslateTransform(offsetX, offsetY);
            _drawingContext!.PushTransform(transform);
        }

        public void PushTransform(ITransform transform)
        {
            Transform wpfTransform = transform.ToWpfTransform();
            _drawingContext!.PushTransform(wpfTransform);
        }

        public void Pop()
        {
            _drawingContext!.Pop();
        }

        public IVisual? Close()
        {
            // TODO: Return null if didn't draw anything
            _drawingContext!.Close();
            _drawingContext = null;
            return new WpfNativeVisual(_drawingGroup);
        }

#if LATER
        private void DrawShapePath(SKPath skPath, IShape shape)
        {
            FillSkiaPath(skPath, shape);
            StrokeSkiaPath(skPath, shape);
        }

        private void FillSkiaPath(SKPath skPath, IShape shape)
        {
            IBrush? fill = shape.Fill;
            if (fill != null)
            {
                using SKPaint paint = new SKPaint { Style = SKPaintStyle.Fill, IsAntialias = true };
                InitSkiaPaintForBrush(paint, fill, shape);
                _skCanvas.DrawPath(skPath, paint);
            }
        }

        private void StrokeSkiaPath(SKPath skPath, IShape shape)
        {
            IBrush? stroke = shape.Stroke;
            if (stroke != null)
            {
                using SKPaint paint = new SKPaint { Style = SKPaintStyle.Stroke, IsAntialias = true };
                InitSkiaPaintForBrush(paint, stroke, shape);
                paint.StrokeWidth = (int)shape.StrokeThickness;
                paint.StrokeMiter = (float)shape.StrokeMiterLimit;

                SKStrokeCap strokeCap = shape.StrokeLineCap switch
                {
                    PenLineCap.Flat => SKStrokeCap.Butt,
                    PenLineCap.Round => SKStrokeCap.Round,
                    PenLineCap.Square => SKStrokeCap.Square,
                    _ => throw new InvalidOperationException($"Unknown PenLineCap value {shape.StrokeLineCap}")
                };
                paint.StrokeCap = strokeCap;

                SKStrokeJoin strokeJoin = shape.StrokeLineJoin switch
                {
                    PenLineJoin.Miter => SKStrokeJoin.Miter,
                    PenLineJoin.Bevel => SKStrokeJoin.Bevel,
                    PenLineJoin.Round => SKStrokeJoin.Round,
                    _ => throw new InvalidOperationException($"Unknown PenLineJoin value {shape.StrokeLineJoin}")
                };
                paint.StrokeJoin = strokeJoin;

                _skCanvas.DrawPath(skPath, paint);
            }
        }
#endif

        public static System.Windows.Media.Pen? ToWpfNativePen(IShape shape)
        {
            IBrush? strokeBrush = shape.Stroke;
            if (strokeBrush == null)
                return null;

            return new System.Windows.Media.Pen(strokeBrush.ToWpfBrush(), shape.StrokeThickness)
            {
                MiterLimit = shape.StrokeMiterLimit,
                StartLineCap = shape.StrokeLineCap.ToWpfPenLineCap(),
                EndLineCap = shape.StrokeLineCap.ToWpfPenLineCap(),
                LineJoin = shape.StrokeLineJoin.ToWpfPenLineJoin()
            };
        }

#if LATER
        private static SKPathFillType FillRuleToSkiaPathFillType(FillRule fillRule)
        {
            return fillRule switch
            {
                FillRule.EvenOdd => SKPathFillType.EvenOdd,
                FillRule.Nonzero => SKPathFillType.Winding,
                _ => throw new InvalidOperationException($"Unknown fillRule value {fillRule}")
            };
        }

        private static SKPoint[] PointsToSkiaPoints(Points points)
        {
            int length = points.Length;
            SKPoint[] skiaPoints = new SKPoint[length];
            for (int i = 0; i < length; i++)
                skiaPoints[i] = new SKPoint((float)points[i].X, (float)points[i].Y);

            return skiaPoints;
        }
#endif
    }
}
