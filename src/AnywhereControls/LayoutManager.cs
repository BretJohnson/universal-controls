using System;
using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Controls
{
    public abstract class LayoutManager<TContainerUIElement> where TContainerUIElement : IUIElement
    {
        public abstract Size MeasureOverride(TContainerUIElement panel, double widthConstraint, double heightConstraint);

        public abstract Size ArrangeOverride(TContainerUIElement panel, Size finalSize);

        public static double ResolveWidthConstraints(IUIElement uiElement, double externalConstraint, double measuredLength)
        {
            // If the width is explicitly set, use that; otherwise use what was measured
            var length = !double.IsNaN(uiElement.Width) ? uiElement.Width : measuredLength;

            if (length > uiElement.MaxWidth)
            {
                length = uiElement.MaxWidth;
            }

            if (length < uiElement.MinWidth)
            {
                length = uiElement.MinWidth;
            }

            if (length > externalConstraint)
            {
                length = externalConstraint;
            }

            return length;
        }

        public static double ResolveHeightConstraints(IUIElement uiElement, double externalConstraint, double measuredLength)
        {
            // If the height sis explicitly set, use that; otherwise use what was measured
            var length = !double.IsNaN(uiElement.Height) ? uiElement.Height : measuredLength;

            if (length > uiElement.MaxHeight)
            {
                length = uiElement.MaxHeight;
            }

            if (length < uiElement.MinHeight)
            {
                length = uiElement.MinHeight;
            }

            if (length > externalConstraint)
            {
                length = externalConstraint;
            }

            return length;
        }

        // TODO: Do more testing to confirm this is correct, always forcing stretch if sizes
        // are set explicitly
        public static Size AdjustForStretchToFill(IUIElement uiElement, double width, double height, Size finalSize)
        {
            if (uiElement.HorizontalAlignment == HorizontalAlignment.Stretch)
            {
                width = Math.Max(finalSize.Width, width);
            }

            if (uiElement.VerticalAlignment == VerticalAlignment.Stretch)
            {
                height = Math.Max(finalSize.Height, height);
            }

            return new Size(width, height);
        }
    }
}
