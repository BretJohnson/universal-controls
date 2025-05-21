using System.ComponentModel;

namespace UniversalUI.Media
{
    [UIModelObject]
    public interface IPathFigure : IUIObject
    {
        IUICollection<IPathSegment> Segments { get; }

        Point StartPoint { get; set; }

        [DefaultValue(false)]
        bool IsClosed { get; set; }

        [DefaultValue(true)]
        bool IsFilled { get; set; }
    }
}
