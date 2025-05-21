using System.ComponentModel;
using UniversalUI.Media;

namespace UniversalUI.Shapes
{
    [UIModelObject]
    public interface IPolygon : IShape
    {
        [DefaultValue(FillRule.EvenOdd)]
        FillRule FillRule { get; set; }

        Points Points { get; set; }
    }
}
