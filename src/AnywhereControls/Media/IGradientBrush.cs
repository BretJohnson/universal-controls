using System.ComponentModel;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface IGradientBrush : IBrush
    {
        /// <summary>
        /// A collection of the GradientStop objects associated with the brush, each of which specifies a color and an offset along the brush's gradient axis. The default is an empty collection.
        /// </summary>
        IUICollection<IGradientStop> GradientStops { get; }

        /// <summary>
        /// A BrushMappingMode value that specifies how to interpret the gradient brush's positioning coordinates. The default is RelativeToBoundingBox.
        /// </summary>
        [DefaultValue(BrushMappingMode.RelativeToBoundingBox)]
        BrushMappingMode MappingMode { get; set; }

        /// <summary>
        /// The type of spread method used to paint the gradient. The default is Pad.
        /// </summary>
        [DefaultValue(GradientSpreadMethod.Pad)]
        GradientSpreadMethod SpreadMethod { get; set; }
    }
}
