using Microsoft.StandardUI.Wpf;

namespace Microsoft.StandardUI.Media.Wpf
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
