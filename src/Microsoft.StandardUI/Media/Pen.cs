namespace Microsoft.StandardUI.Media
{
    public class Pen
    {
        public IBrush? Brush { get; set; }

        public double MiterLimit { get; set; } = 10.0;

        public double Thickness { get; set; } = 1.0;

        public PenLineCap StartLineCap { get; set; } = PenLineCap.Flat;

        public PenLineCap EndLineCap { get; set; } = PenLineCap.Flat;

        public PenLineJoin LineJoin { get; set; } = PenLineJoin.Miter;
    }
}
