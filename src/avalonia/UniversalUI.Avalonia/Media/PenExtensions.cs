using UniversalUI.Media;

namespace AnywhereControlsAvalonia.Media
{
    public static class PenExtensions
    {
        public static Avalonia.Media.Pen ToAvaloniaPen(this Pen pen) =>
            new Avalonia.Media.Pen(pen.Brush?.ToAvaloniaBrush(), pen.Thickness)
            {
                MiterLimit = pen.MiterLimit,
                LineCap = pen.StartLineCap.ToAvaloniaPenLineCap(),
                LineJoin = pen.LineJoin.ToAvaloniaPenLineJoin()
            };
    }
}
