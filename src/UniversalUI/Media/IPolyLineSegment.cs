namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IPolyLineSegment : IPathSegment
    {
        Points Points { get; set; }
    }
}
