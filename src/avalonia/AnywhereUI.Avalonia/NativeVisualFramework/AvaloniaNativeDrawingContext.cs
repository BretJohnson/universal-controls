using System.Globalization;
using AnywhereUI.Controls;
using AnywhereUI.Shapes;
using AnywhereUIAvalonia.Media;
using Pen = AnywhereControls.Media.Pen;
using Avalonia.Media;
using IBrush = AnywhereControls.Media.IBrush;
using ITransform = AnywhereControls.Media.ITransform;
using AnywhereUI;
using AnywhereUIAvalonia.Text;

namespace AnywhereControlsAvalonia.NativeVisualFramework
{
    public class AvaloniaNativeDrawingContext : IDrawingContext
    {
        private DrawingGroup _drawingGroup;
        private DrawingContext? _drawingContext;
        private Stack<DrawingContext.PushedState> _stateStack = new();

        public AvaloniaNativeDrawingContext()
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

        public void DrawEllipse(IEllipse ellipse)
        {
            Avalonia.Media.Brush? avaloniaBrush = ellipse.Fill.ToAvaloniaBrush();
            Avalonia.Media.Pen? avaloniaPen = ToAvaloniaNativePen(ellipse);

            double radiusX = ellipse.ActualWidth / 2;
            double radiusY = ellipse.ActualHeight / 2;
            var center = new Avalonia.Point(radiusX, radiusY);

            _drawingContext!.DrawEllipse(avaloniaBrush, avaloniaPen, center, radiusX, radiusY);
        }

        public void DrawLine(ILine line)
        {
            Avalonia.Media.Pen? avaloniaPen = ToAvaloniaNativePen(line);
            if (avaloniaPen != null)
            {
                _drawingContext!.DrawLine(avaloniaPen,
                    new Avalonia.Point(line.X1, line.Y1),
                    new Avalonia.Point(line.X2, line.Y2));
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
            Avalonia.Rect avaloniaRect = rect.ToAvaloniaRect();
            Avalonia.Media.Brush? avaloniaBrush = brush?.ToAvaloniaBrush();
            Avalonia.Media.Pen? avaloniaPen = pen?.ToAvaloniaPen();

            _drawingContext!.DrawRectangle(avaloniaBrush, avaloniaPen, avaloniaRect);
        }

        public void DrawRoundedRectangle(IBrush? brush, Pen? pen, Rect rect, double radiusX, double radiusY)
        {
            Avalonia.Rect avaloniaRect = rect.ToAvaloniaRect();
            Avalonia.Media.Brush? avaloniaBrush = brush?.ToAvaloniaBrush();
            Avalonia.Media.Pen? avaloniaPen = pen?.ToAvaloniaPen();

            _drawingContext!.DrawRectangle(avaloniaBrush, avaloniaPen, avaloniaRect, radiusX, radiusY);
        }

        public void DrawRectangle(IRectangle rectangle)
        {
            Avalonia.Rect avaloniaRect = new Avalonia.Rect(0, 0, rectangle.ActualWidth, rectangle.ActualHeight);

            Avalonia.Media.Brush? avaloniaBrush = rectangle.Fill.ToAvaloniaBrush();
            Avalonia.Media.Pen? avaloniaPen = ToAvaloniaNativePen(rectangle);

            if (rectangle.RadiusX > 0 || rectangle.RadiusY > 0)
                _drawingContext!.DrawRectangle(avaloniaBrush, avaloniaPen, avaloniaRect, rectangle.RadiusX, rectangle.RadiusY);
            else
                _drawingContext!.DrawRectangle(avaloniaBrush, avaloniaPen, avaloniaRect);
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
            Avalonia.Media.Brush? brush = textBlock.Foreground.ToAvaloniaBrush();
            if (brush == null)
                return;

            var typeface = new Typeface(textBlock.FontFamily.ToAvaloniaFontFamily(),
                textBlock.FontStyle.ToAvaloniaFontStyle(),
                textBlock.FontWeight.ToAvaloniaFontWeight(),
                textBlock.FontStretch.ToAvaloniaFontStretch());

            // Create the initial formatted text string.
            FormattedText formattedText = new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToAvaloniaFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush);

            _drawingContext!.DrawText(formattedText, new Avalonia.Point(0, 0));
        }

        public void PushRotateTransform(double angle, double centerX, double centerY)
        {
            var transform = new Avalonia.Media.RotateTransform(
                angle: angle,
                centerX: centerX,
                centerY: centerY);
            _stateStack.Push(_drawingContext!.PushTransform(transform.Value));
        }

        public void PushTranslateTransform(double offsetX, double offsetY)
        {
            var transform = new Avalonia.Media.TranslateTransform(offsetX, offsetY);
            _stateStack.Push(_drawingContext!.PushTransform(transform.Value));
        }

        public void PushTransform(ITransform transform)
        {
            Avalonia.Media.Transform avaloniaTransform = transform.ToAvaloniaTransform();
            _stateStack.Push(_drawingContext!.PushTransform(avaloniaTransform.Value));
        }

        public void Pop()
        {
            DrawingContext.PushedState poppedElement = _stateStack.Pop();
            poppedElement.Dispose();
        }

        public IVisual? Close()
        {
            // TODO: Return null if didn't draw anything
            //_drawingContext!.Close();
            _drawingContext = null;
            return new AvaloniaNativeVisual(_drawingGroup);
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

        public static Avalonia.Media.Pen? ToAvaloniaNativePen(IShape shape)
        {
            IBrush? strokeBrush = shape.Stroke;
            if (strokeBrush == null)
                return null;

            return new Avalonia.Media.Pen(strokeBrush.ToAvaloniaBrush(), shape.StrokeThickness)
            {
                MiterLimit = shape.StrokeMiterLimit,
                LineCap = shape.StrokeLineCap.ToAvaloniaPenLineCap(),
                LineJoin = shape.StrokeLineJoin.ToAvaloniaPenLineJoin()
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
