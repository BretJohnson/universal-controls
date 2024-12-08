namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IPolyQuadraticBezierSegment : IPathSegment
    {
        Points Points { get; set; }
    }
}
