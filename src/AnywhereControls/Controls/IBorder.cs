using System.ComponentModel;
using Microsoft.Maui.Graphics;
using AnywhereControls.Media;

namespace AnywhereControls.Controls
{
    [UIModelObject]
    public interface IBorder : IUIElement
    {
        /// <summary>
        /// Gets or sets the Brush that fills the background (inner area) of the border.
        /// </summary>
        [DefaultValue(null)]
        public IBrush Background { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates how far the background extends in relation to this element's border.
        /// </summary>
        [DefaultValue(BackgroundSizing.InnerBorderEdge)]
        BackgroundSizing BackgroundSizing { get; set; }

        /// <summary>
        /// Gets or sets the Brush that is applied to the edge area of the Border.
        /// </summary>
        [DefaultValue(null)]
        public IBrush BorderBrush { get; set; }

        /// <summary>
        /// Gets or sets the thickness of the border.
        /// </summary>
        public Thickness BorderThickness { get; set; }

        /// <summary>
        /// Gets or sets the child element to draw the border around.
        /// </summary>
        [DefaultValue(null)]
        public IUIElement Child { get; set; }

        /// <summary>
        /// Gets or sets the radius for the corners of the border.
        /// </summary>
        public CornerRadius CornerRadius { get; set; }

        /// <summary>
        /// Gets or sets the distance between the border and its child object.
        /// </summary>
        public Thickness Padding { get; set; }
    }
}
