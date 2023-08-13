using System;
using System.Numerics;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Hosting;
using PenLineCap = Microsoft.StandardUI.Media.PenLineCap;
using PenLineJoin = Microsoft.StandardUI.Media.PenLineJoin;

namespace Microsoft.StandardUI.WinUI.NativeVisualFramework
{
    public class WinUINativeDrawingContext : IDrawingContext
    {
        private readonly Compositor _compositor;
        private ContainerVisual? _containerVisual = null;
        private ShapeVisual? _shapeVisual = null;
        private bool _disposed;

        public WinUINativeDrawingContext(IUIElement uiElement)
        {
            if (uiElement is not Microsoft.UI.Xaml.UIElement winUIUIElement)
            {
                throw new InvalidOperationException($"uiElement is of type {uiElement.GetType()}, not of expected type Microsoft.UI.Xaml.UIElement");
            }

            _compositor = ElementCompositionPreview.GetElementVisual(winUIUIElement).Compositor;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _shapeVisual?.Dispose();
                    _containerVisual?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DrawEllipse(IEllipse ellipse)
        {
#if false
            Brush? wpfBrush = ellipse.Fill.ToWpfBrush();
            Pen? wpfPen = ToWpfNativePen(ellipse);

            double radiusX = ellipse.Width / 2;
            double radiusY = ellipse.Height / 2;
            var center = new System.Windows.Point(radiusX, radiusY);

            _drawingContext!.DrawEllipse(wpfBrush, wpfPen, center, radiusX, radiusY);
#endif
            throw new NotImplementedException("TODO: Implement DrawEllipse for WinUI");
        }

        public void DrawLine(ILine line)
        {
            CompositionLineGeometry lineGeometry = _compositor.CreateLineGeometry();
            lineGeometry.Start = new Vector2((float)line.X1, (float)line.X2);
            lineGeometry.End = new Vector2((float)line.X2, (float)line.Y2);

            DrawShapeGeometry(lineGeometry, line);
        }

        public void DrawPath(IPath path)
        {
            throw new NotImplementedException("TODO: Implement DrawPath for WinUI");
        }

        public void DrawPolygon(IPolygon polygon)
        {
#if LATER
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polygon.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polygon.Points), close: true);

            DrawShapePath(skPath, polygon);
#endif
            throw new NotImplementedException("TODO: Implement DrawPolygon for WinUI");
        }

        public void DrawPolyline(IPolyline polyline)
        {
#if LATER
            SKPath skPath = new SKPath();
            skPath.FillType = FillRuleToSkiaPathFillType(polyline.FillRule);
            skPath.AddPoly(PointsToSkiaPoints(polyline.Points), close: false);

            DrawShapePath(skPath, polyline);
#endif
            throw new NotImplementedException("TODO: Implement DrawPolyline for WinUI");
        }

        public void DrawRectangle(IRectangle rectangle)
        {
            Vector2 size = new Vector2((float)rectangle.Width, (float)rectangle.Height);

            if (rectangle.RadiusX > 0 || rectangle.RadiusY > 0)
            {
                CompositionRoundedRectangleGeometry roundedRectangleGeometry = _compositor.CreateRoundedRectangleGeometry();
                roundedRectangleGeometry.Size = size;
                roundedRectangleGeometry.CornerRadius = new Vector2((float)rectangle.RadiusX, (float)rectangle.RadiusY);

                DrawShapeGeometry(roundedRectangleGeometry, rectangle);
            }
            else
            {
                CompositionRectangleGeometry rectangleGeometry = _compositor.CreateRectangleGeometry();
                rectangleGeometry.Size = size;

                DrawShapeGeometry(rectangleGeometry, rectangle);
            }
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
#if LATER
            Brush? brush = textBlock.Foreground.ToWinUIBrush();
            if (brush == null)
                return;

            var typeface = new Typeface( textBlock.FontFamily.ToWinUIFontFamily(),
                textBlock.FontStyle.ToWinUIFontStyle(),
                textBlock.FontWeight.ToWinUIFontWeight(),
                textBlock.FontStretch.ToWinUIFontStretch());

            // Create the initial formatted text string.
            FormattedText formattedText = new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToWinUIFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush,
                1.0); // TODO: Set this appropriately

            _drawingContext!.DrawText(formattedText, new System.Windows.Point(0, 0));
#endif
        }

        /// <summary>
        /// Close the DrawingContext and return the resulting visual. There are three
        /// cases: (1) If nothing was drawn, null is returned. (2) If only shapes were
        /// drawng, a ShapeVisual is returned. (3) Otherwise, a ContainerVisual is returned.
        /// </summary>
        /// <returns>resulting visual or null</returns>
        public IVisual? Close()
        {
            Visual? visual;
            if (_containerVisual == null)
            {
                visual = _shapeVisual;
            }
            else
            {
                if (_shapeVisual != null)
                {
                    _containerVisual.Children.InsertAtTop(_shapeVisual);
                }

                visual = _containerVisual;
            }

            _containerVisual = null;
            _shapeVisual = null;

            return visual == null ? null : new WinUINativeVisual(visual);
        }

        private void DrawShapeGeometry(CompositionGeometry geometry, IShape shape)
        {
            CompositionSpriteShape spriteShape = _compositor.CreateSpriteShape(geometry);

            IBrush? fill = shape.Fill;
            if (fill != null)
            {
                spriteShape.FillBrush = fill.ToCompositionBrush(_compositor);
            }

            IBrush? stroke = shape.Stroke;
            if (stroke != null)
            {
                spriteShape.StrokeBrush = stroke.ToCompositionBrush(_compositor);
                spriteShape.StrokeThickness = (float)shape.StrokeThickness;

                CompositionStrokeCap strokeCap = shape.StrokeLineCap switch
                {
                    PenLineCap.Flat => CompositionStrokeCap.Flat,
                    PenLineCap.Round => CompositionStrokeCap.Round,
                    PenLineCap.Square => CompositionStrokeCap.Square,
                    _ => throw new InvalidOperationException($"Unknown PenLineCap value {shape.StrokeLineCap}")
                };
                spriteShape.StrokeStartCap = strokeCap;
                spriteShape.StrokeEndCap = strokeCap;

                spriteShape.StrokeLineJoin = shape.StrokeLineJoin switch
                {
                    PenLineJoin.Miter => CompositionStrokeLineJoin.Miter,
                    PenLineJoin.Bevel => CompositionStrokeLineJoin.Bevel,
                    PenLineJoin.Round => CompositionStrokeLineJoin.Round,
                    _ => throw new InvalidOperationException($"Unknown PenLineJoin value {shape.StrokeLineJoin}")
                };

                // TODO: Check that miter limit definition matches StandardUI (half thickness vs full thickness)
                spriteShape.StrokeMiterLimit = (float)shape.StrokeMiterLimit;

                // TODO: Handle dash pattern
            }

            if (_shapeVisual == null)
            {
                _shapeVisual = _compositor.CreateShapeVisual();
            }

            _shapeVisual.Shapes.Add(spriteShape);
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

        public void PushTransform(ITransform transform)
        {
            throw new NotImplementedException();
        }

        public void Pop()
        {
            throw new NotImplementedException();
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
