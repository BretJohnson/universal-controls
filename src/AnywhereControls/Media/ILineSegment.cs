using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface ILineSegment : IPathSegment
    {
        Point Point { get; set; }
    }
}
