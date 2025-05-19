using System.ComponentModel;
using AnywhereUI.Media;

namespace AnywhereUI.Shapes
{
    [UIModelObject]
    public interface IPolygon : IShape
    {
        [DefaultValue(FillRule.EvenOdd)]
        FillRule FillRule { get; set; }

        Points Points { get; set; }
    }
}
