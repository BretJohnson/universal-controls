using System.ComponentModel;

namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IPathGeometry : IGeometry
    {
        IUICollection<IPathFigure> Figures { get; }

        [DefaultValue(FillRule.EvenOdd)]
        FillRule FillRule { get; set; }
    }
}
