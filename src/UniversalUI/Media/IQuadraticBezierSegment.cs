namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IQuadraticBezierSegment : IPathSegment
    {
        Point Point1 { get; set; }

        Point Point2 { get; set; }
    }
}
