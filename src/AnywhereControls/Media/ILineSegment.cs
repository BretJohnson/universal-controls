using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ILineSegment : IPathSegment
    {
        Point Point { get; set; }
    }
}
