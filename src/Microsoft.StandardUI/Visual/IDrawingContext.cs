using System;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI
{
    /// <summary>
    /// A IDrawingContext turns cross platform vector graphics into an IVisual, a platform specific representation those graphics.
    /// The graphics in the IVisual aren't actually rendered; they are just remembered, as is appropriate for a retained mode
    /// graphics system, for later rendering. For instance, for the Skia visual environment, an IVisual maps to an SkPicture.
    /// For WPF native, IVisual maps to a DrawingVisual. The retained graphics in the IVisual may be cached on the GPU.
    /// </summary>
    public interface IDrawingContext : IDisposable
    {
        void DrawEllipse(IEllipse ellipse);
        void DrawLine(ILine line);
        void DrawPath(IPath path);
        void DrawPolygon(IPolygon polygon);
        void DrawPolyline(IPolyline polyline);
        void DrawRectangle(IRectangle rectangle);

        void DrawRectangle(IBrush? brush, Pen? pen, Rect rect);
        void DrawRoundedRectangle(IBrush? brush, Pen? pen, Rect rect, double radiusX, double radiusY);

        void DrawTextBlock(ITextBlock textBlock);

        void PushRotateTransform(double angle, double centerX, double centerY);
        void PushTranslateTransform(double offsetX, double offsetY);
        void PushTransform(ITransform transform);
        void Pop();

        IVisual? Close();
    }
}
