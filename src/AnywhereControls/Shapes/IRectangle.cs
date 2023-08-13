using System.ComponentModel;

namespace Microsoft.StandardUI.Shapes
{
    [UIModelObject]
    public interface IRectangle : IShape
    {
        /// <summary>
        /// Gets or sets the x-axis radius of the ellipse that is used to round the corners of the rectangle.
        /// </summary>
        [DefaultValue(0.0)]
        double RadiusX { get; set; }

        /// <summary>
        /// Gets or sets the y-axis radius of the ellipse that is used to round the corners of the rectangle.
        /// </summary>
        [DefaultValue(0.0)]
        double RadiusY { get; set; }
    }
}
