using UniversalUI.Controls;
using UniversalUI.Media;
using UniversalUI.Shapes;
using System;

namespace UniversalUI.Maui.NativeVisualFramework
{
    public class MauiNativeDrawingContext : IDrawingContext
    {
        Microsoft.Maui.Graphics.ICanvas? _canvas;

        public MauiNativeDrawingContext(Microsoft.Maui.Graphics.ICanvas canvas)
        {
            _canvas = canvas;
        }

        protected virtual void Dispose(bool disposing)
        {
            _canvas = null;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DrawEllipse(IEllipse ellipse)
        {
            float radiusX = (float)ellipse.ActualWidth / 2;
            float radiusY = (float)ellipse.ActualHeight / 2;
            var center = new Microsoft.Maui.Graphics.Point(radiusX, radiusY);

            // Stroke
            Microsoft.Maui.Graphics.Color? strokeColor = ellipse.Stroke.ToMauiColor();

            if (strokeColor != null)
            {
                _canvas!.StrokeColor = strokeColor;
                _canvas!.StrokeSize = (float)ellipse.StrokeThickness;
                _canvas!.DrawEllipse((float)center.X, (float)center.Y, radiusX, radiusY);
            }

            // Fill
            Microsoft.Maui.Graphics.Paint? fill = ellipse.Fill.ToMauiBrush();

            if (fill is not null)
            {
                var rect = new Microsoft.Maui.Graphics.Rect(0, 0, ellipse.ActualWidth, ellipse.ActualHeight);
                _canvas!.SetFillPaint(fill, rect);
                _canvas!.FillEllipse((float)center.X, (float)center.Y, radiusX, radiusY);
            }
        }

        public void DrawLine(ILine line)
        {
            Microsoft.Maui.Graphics.Color? strokeColor = line.Stroke.ToMauiColor();

            if (strokeColor != null)
            {
                _canvas!.StrokeColor = strokeColor;
                _canvas!.StrokeSize = (float)line.StrokeThickness;
                _canvas!.DrawLine((float)line.X1, (float)line.Y1, (float)line.X2, (float)line.Y2);
            }
        }

        public void DrawPath(IPath path)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygon(IPolygon polygon)
        {
            throw new NotImplementedException();
        }

        public void DrawPolyline(IPolyline polyline)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle(IBrush? brush, Pen? pen, Rect rect)
        {
            Microsoft.Maui.Graphics.Paint? mauiBrush = brush.ToMauiBrush();

            if (mauiBrush is not null)
            {
                _canvas!.SetFillPaint(mauiBrush, rect.ToMauiRect());

                _canvas!.FillRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
            }
        }

        public void DrawRoundedRectangle(IBrush? brush, Pen? pen, Rect rect, double radiusX, double radiusY)
        {
            float radius = (float)(radiusX + radiusY / 2);

            // Stroke
            Microsoft.Maui.Graphics.Color? strokeColor = pen?.Brush.ToMauiColor();

            if (strokeColor != null)
            {
                _canvas!.StrokeColor = strokeColor;
                _canvas!.DrawRoundedRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height, radius);
            }

            // Fill
            Microsoft.Maui.Graphics.Paint? mauiBrush = brush.ToMauiBrush();

            if (mauiBrush is not null)
            {
                _canvas!.SetFillPaint(mauiBrush, rect.ToMauiRect());
                _canvas!.FillRoundedRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height, radius);
            }
        }

        public void DrawRectangle(IRectangle rectangle)
        {
            var rect = new Microsoft.Maui.Graphics.Rect(0, 0, rectangle.ActualWidth, rectangle.ActualHeight);

            // Stroke
            Microsoft.Maui.Graphics.Color? strokeColor = rectangle.Stroke.ToMauiColor();

            if (strokeColor != null)
            {
                _canvas!.StrokeColor = strokeColor;
                _canvas!.StrokeSize = (float)rectangle.StrokeThickness;
                _canvas!.DrawRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
            }

            // Fill
            Microsoft.Maui.Graphics.Paint? fill = rectangle.Fill.ToMauiBrush();

            if (fill is not null)
            {
                _canvas!.SetFillPaint(fill, rect);
                _canvas!.FillRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
            }
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
            Microsoft.Maui.Graphics.Color? foreground = textBlock.Foreground.ToMauiColor();

            _canvas!.FontColor = foreground;
            _canvas!.FontSize = (float)textBlock.FontSize;

            _canvas!.DrawString(textBlock.Text, 0, 0, Microsoft.Maui.Graphics.HorizontalAlignment.Left);
        }

        public void PushRotateTransform(double angle, double centerX, double centerY)
        { 
            _canvas!.Rotate((float)angle, (float) centerX, (float) centerY);
        }

        public void PushTranslateTransform(double offsetX, double offsetY)
        {
            _canvas!.Translate((float)offsetX, (float)offsetY);
        }

        public void PushTransform(ITransform transform)
        {
            throw new NotImplementedException();
        }

        public void Pop()
        {
        
        }

        public IVisual? Close()
        {
            // TODO: Return null if didn't draw anything
            return new MauiNativeVisual(_canvas!);
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