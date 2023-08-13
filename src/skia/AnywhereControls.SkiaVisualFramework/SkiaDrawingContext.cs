using System;
using System.Collections.Generic;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;
using SkiaSharp;

namespace Microsoft.StandardUI.SkiaVisualFramework
{
    public class SkiaDrawingContext : IDrawingContext
    {
        private SKPictureRecorder? _skPictureRecorder;
        private SKCanvas _skCanvas;

        public SkiaDrawingContext()
        {
            _skPictureRecorder = new SKPictureRecorder();

            SKRect skCullingRect = SKRect.Create(float.NegativeInfinity, float.NegativeInfinity, float.PositiveInfinity, float.PositiveInfinity);
            _skCanvas = _skPictureRecorder.BeginRecording(skCullingRect);
        }

        public SkiaDrawingContext(SKCanvas canvas)
        {
            _skCanvas = canvas;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_skPictureRecorder != null)
            {
                if (disposing)
                    _skPictureRecorder.Dispose();

                _skPictureRecorder = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DrawEllipse(IEllipse ellipse)
        {
            SKPath skPath = new SKPath();
            SKRect skRect = SKRect.Create(0, 0, (float)ellipse.ActualWidth, (float)ellipse.ActualHeight);
            skPath.AddOval(skRect);

            DrawShapePath(skPath, ellipse);
        }

        public void DrawLine(ILine line)
        {
            SKPath skPath = new SKPath();
            skPath.MoveTo((float)line.X1, (float)line.Y1);
            skPath.LineTo((float)line.X2, (float)line.Y2);

            DrawShapePath(skPath, line);
        }

        public void DrawPath(IPath path)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygon(IPolygon polygon)
        {
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polygon.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polygon.Points), close: true);

            DrawShapePath(skPath, polygon);
        }

        public void DrawPolyline(IPolyline polyline)
        {
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polyline.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polyline.Points), close: false);

            DrawShapePath(skPath, polyline);
        }

        public void DrawRectangle(IRectangle rectangle)
        {
            SKPath skPath = new SKPath();
            SKRect skRect = SKRect.Create(0, 0, (float)rectangle.ActualWidth, (float)rectangle.ActualHeight);
            if (rectangle.RadiusX > 0 || rectangle.RadiusY > 0)
                skPath.AddRoundRect(skRect, (float)rectangle.RadiusX, (float)rectangle.RadiusY);
            else
                skPath.AddRect(skRect);

            DrawShapePath(skPath, rectangle);
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
            IBrush? foreground = textBlock.Foreground;
            if (foreground != null)
            {
                using SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    TextSize = (float)textBlock.FontSize,
                    IsAntialias = true
                };

                SKRect textBounds = new SKRect();
                paint.MeasureText(textBlock.Text, ref textBounds);
                float baseline = -textBounds.Top;

                if (foreground is IGradientBrush foregroundGradientBrush)
                    InitSkiaPaintForGradientBrush(paint, foregroundGradientBrush, textBounds.Size);
                else InitSkiaPaintForNongradientBrush(paint, foreground);

                _skCanvas.DrawText(textBlock.Text, 0, baseline, paint);
            }
        }

        public IVisual Close()
        {
            SKPicture skPicture = _skPictureRecorder!.EndRecording();
            return new SkiaVisual(skPicture);
        }

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

                if (fill is IGradientBrush fillGradientBrush)
                {
                    SKRect tightBounds = skPath.TightBounds;
                    InitSkiaPaintForGradientBrush(paint, fillGradientBrush, tightBounds.Size);
                }
                else InitSkiaPaintForNongradientBrush(paint, fill);

                _skCanvas.DrawPath(skPath, paint);
            }
        }

        private void StrokeSkiaPath(SKPath skPath, IShape shape)
        {
            IBrush? stroke = shape.Stroke;
            if (stroke != null)
            {
                using SKPaint paint = new SKPaint { Style = SKPaintStyle.Stroke, IsAntialias = true };

                if (stroke is IGradientBrush strokeGradientBrush)
                {
                    SKRect tightBounds = skPath.TightBounds;
                    InitSkiaPaintForGradientBrush(paint, strokeGradientBrush, tightBounds.Size);
                }
                else InitSkiaPaintForNongradientBrush(paint, stroke);

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

        private static void InitSkiaPaintForNongradientBrush(SKPaint paint, IBrush brush)
        {
            if (brush is ISolidColorBrush solidColorBrush)
                paint.Color = ToSkiaColor(solidColorBrush.Color);
            else if (brush is IGradientBrush gradientBrush)
                throw new InvalidOperationException($"InitSkiaPaintForBrush: Use InitSkiaPaintForGradientBrush instead for gradient brush type {brush.GetType()}");
            else throw new InvalidOperationException($"InitSkiaPaintForBrush: Brush type {brush.GetType()} isn't currently supported");
        }

        private static void InitSkiaPaintForGradientBrush(SKPaint paint, IGradientBrush gradientBrush, SKSize boundingBoxSize)
        {
            paint.Shader = ToSkiaShader(gradientBrush, boundingBoxSize);
        }

        public static SKColor ToSkiaColor(Color color)
        {
            var r = (byte)(color.Red * 255f);
            var g = (byte)(color.Green * 255f);
            var b = (byte)(color.Blue * 255f);
            var a = (byte)(color.Alpha * 255f);

            return new SKColor(r, g, b, a);
        }

        public static SKShader ToSkiaShader(IGradientBrush gradientBrush, SKSize boundingBoxSize)
        {
            SKShaderTileMode tileMode = gradientBrush.SpreadMethod switch
            {
                GradientSpreadMethod.Pad => SKShaderTileMode.Clamp,
                GradientSpreadMethod.Reflect => SKShaderTileMode.Mirror,
                GradientSpreadMethod.Repeat => SKShaderTileMode.Repeat,
                _ => throw new InvalidOperationException($"Unknown GradientSpreadMethod value {gradientBrush.SpreadMethod}")
            };

            List<SKColor> skColors = new List<SKColor>();
            List<float> skiaColorPositions = new List<float>();
            foreach (IGradientStop gradientStop in gradientBrush.GradientStops)
            {
                skColors.Add(ToSkiaColor(gradientStop.Color));
                skiaColorPositions.Add((float)gradientStop.Offset);
            }

            if (gradientBrush is ILinearGradientBrush linearGradientBrush)
            {
                SKPoint skiaStartPoint = GradientBrushPointToSkiaPoint(linearGradientBrush.StartPoint, gradientBrush, boundingBoxSize);
                SKPoint skiaEndPoint = GradientBrushPointToSkiaPoint(linearGradientBrush.EndPoint, gradientBrush, boundingBoxSize);

                return SKShader.CreateLinearGradient(skiaStartPoint, skiaEndPoint, skColors.ToArray(), skiaColorPositions.ToArray(), tileMode);
            }
            else if (gradientBrush is IRadialGradientBrush radialGradientBrush)
            {
                SKPoint skiaCenterPoint = GradientBrushPointToSkiaPoint(radialGradientBrush.Center, gradientBrush, boundingBoxSize);

                float radius = (float)(radialGradientBrush.RadiusX * boundingBoxSize.Width);
                return SKShader.CreateRadialGradient(skiaCenterPoint, radius, skColors.ToArray(), skiaColorPositions.ToArray(), tileMode);
            }
            else throw new InvalidOperationException($"GradientBrush type {gradientBrush.GetType()} is unknown");
        }

        public static SKPoint GradientBrushPointToSkiaPoint(Point point, IGradientBrush gradientBrush, SKSize boundingBoxSize)
        {
            if (gradientBrush.MappingMode == BrushMappingMode.RelativeToBoundingBox)
                return new SKPoint(
                    (float)(point.X * boundingBoxSize.Width),
                    (float)(point.Y * boundingBoxSize.Height));
            else
                return new SKPoint((float)point.X, (float)point.Y);
        }

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

        public void DrawRectangle(IBrush? brush, Pen? pen, Rect rect)
        {
            throw new NotImplementedException();
        }

        public void DrawRoundedRectangle(IBrush? brush, Pen? pen, Rect rect, double radiusX, double radiusY)
        {
            throw new NotImplementedException();
        }

        public void PushRotateTransform(double angle, double centerX, double centerY)
        {
            throw new NotImplementedException();
        }

        public void PushTranslateTransform(double offsetX, double offsetY)
        {
            _skCanvas.Save();
            _skCanvas.Translate((float) offsetX, (float)offsetY);
        }

        public void PushTransform(ITransform transform)
        {
            throw new NotImplementedException();
        }

        public void Pop()
        {
            _skCanvas.Restore();
        }
    }
}
