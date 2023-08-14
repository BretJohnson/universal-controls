using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ILineSegment : IPathSegment
    {
        Point Point { get; set; }
    }
}
