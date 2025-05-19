using AnywhereUI.Media;

namespace AnywhereUI.Wpf.Media
{
    public static class PenExtensions
    {
        public static System.Windows.Media.Pen ToWpfPen(this Pen pen) =>
            new System.Windows.Media.Pen(pen.Brush?.ToWpfBrush(), pen.Thickness)
            {
                MiterLimit = pen.MiterLimit,
                StartLineCap = pen.StartLineCap.ToWpfPenLineCap(),
                EndLineCap = pen.EndLineCap.ToWpfPenLineCap(),
                LineJoin = pen.LineJoin.ToWpfPenLineJoin()
            };
    }
}
