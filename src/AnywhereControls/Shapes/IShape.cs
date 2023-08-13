using System.ComponentModel;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Shapes
{
    [UIModelObject]
    public interface IShape : IUIElement
    {
        /// <summary>
        /// A Brush that paints/fills the shape interior. The default is null (a null brush) which is evaluated as Transparent for rendering.
        /// </summary>
        [DefaultValue(null)]
        IBrush? Fill { get; set; }

        /// <summary>
        /// A Brush that specifies how the Shape outline is painted. The default is null.
        /// </summary>
        [DefaultValue(null)]
        IBrush? Stroke { get; set; }

        /// <summary>
        /// The width of the Shape outline, in pixels. The default value is 0.
        /// </summary>
        [DefaultValue(1.0)]
        double StrokeThickness { get; set; }

        /// <summary>
        /// The limit on the ratio of the miter length to the StrokeThickness of a Shape element. This value is always a positive number that is greater than or equal to 1.
        /// </summary>
        [DefaultValue(10.0)]
        double StrokeMiterLimit { get; set; }

        /// <summary>
        /// A value of the PenLineCap enumeration that specifies the shape at the start and end of a Stroke. The default is Flat.
        /// </summary>
        [DefaultValue(PenLineCap.Flat)]
        PenLineCap StrokeLineCap { get; set; }

        /// <summary>
        /// A value of the PenLineJoin enumeration that specifies the join appearance. The default value is Miter.
        /// </summary>
        [DefaultValue(PenLineJoin.Miter)]
        PenLineJoin StrokeLineJoin { get; set; }
    }
}
