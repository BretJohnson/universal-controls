using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface IBezierSegment : IPathSegment
    {
        Point Point1 { get; set; }

        Point Point2 { get; set; }

        Point Point3 { get; set; }
    }
}
