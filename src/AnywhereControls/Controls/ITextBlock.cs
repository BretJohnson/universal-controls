using System.ComponentModel;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Text;

namespace Microsoft.StandardUI.Controls
{
    [UIModelObject]
    public interface ITextBlock : IUIElement
    {
        /// <summary>
        /// Gets or sets the Brush to apply to the text contents of the TextBlock.
        /// </summary>
        [DefaultValue(null)]
        public IBrush Foreground { get; set; }

        /// <summary>
        /// Gets or sets the text contents of a TextBlock.
        /// </summary>
        [DefaultValue("")]
        string Text { get; set; }

        FontFamily FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the font style for the content in this element.
        /// </summary>
        [DefaultValue(FontStyle.Normal)]
        FontStyle FontStyle { get; set; }

        /// <summary>
        /// The top-level font weight for the TextBlock.
        /// </summary>
        FontWeight FontWeight { get; set; }

        /// <summary>
        /// The font size for the text content in this element
        /// </summary>
        [DefaultValue(11.0)]
        double FontSize { get; set; }

        /// <summary>
        /// The font stretch for the text content in this element
        /// </summary>
        [DefaultValue(FontStretch.Normal)]
        FontStretch FontStretch { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the horizontal alignment of text content.
        /// </summary>
        [DefaultValue(TextAlignment.Left)]
        TextAlignment TextAlignment { get; set; }
    }
}
