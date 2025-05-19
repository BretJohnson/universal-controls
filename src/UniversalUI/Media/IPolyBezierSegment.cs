namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IPolyBezierSegment : IPathSegment
    {
        Points Points { get; set; }
    }
}
