using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface IQuadraticBezierSegment : IPathSegment
    {
        Point Point1 { get; set; }

        Point Point2 { get; set; }
    }
}
