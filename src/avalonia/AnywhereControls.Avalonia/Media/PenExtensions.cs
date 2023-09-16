using AnywhereControls.Media;

namespace AnywhereControls.Avalonia.Media
{
    public static class PenExtensions
    {
        public static global::Avalonia.Media.Pen ToWpfPen(this Pen pen) =>
            new global::Avalonia.Media.Pen(pen.Brush?.ToAvaloniaBrush(), pen.Thickness)
            {
                MiterLimit = pen.MiterLimit,
                LineCap = pen.StartLineCap.ToAvaloniaPenLineCap(),
                LineJoin = pen.LineJoin.ToAvaloniaPenLineJoin()
            };
    }
}
