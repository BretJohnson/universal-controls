using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface IQuadraticBezierSegment : IPathSegment
    {
        Point Point1 { get; set; }

        Point Point2 { get; set; }
    }
}
