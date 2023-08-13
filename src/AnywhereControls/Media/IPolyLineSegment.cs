namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface IPolyLineSegment : IPathSegment
    {
        Points Points { get; set; }
    }
}
