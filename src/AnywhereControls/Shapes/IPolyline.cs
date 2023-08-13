using System.ComponentModel;
using AnywhereControls.Media;

namespace AnywhereControls.Shapes
{
    [UIModelObject]
    public interface IPolyline : IShape
    {
        [DefaultValue(FillRule.EvenOdd)]
        FillRule FillRule { get; set; }

        Points Points { get; set; }
    }
}
