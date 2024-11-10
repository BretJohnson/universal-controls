using System;
using static AnywhereControls.Dimension;

namespace AnywhereControls
{
    public static class LayoutExtensions
    {
        public static Rect ComputeFrame(this IUIElement view, Rect bounds)
        {
            Thickness margin = view.Margin;

            // We need to determine the width the element wants to consume; normally that's the element's DesiredSize.Width
            var consumedWidth = view.DesiredSize.Width;

            if (view.HorizontalAlignment == HorizontalAlignment.Stretch && !IsExplicitSet(view.Width))
            {
                // But if the element is set to fill horizontally and it doesn't have an explicitly set width,
                // then we want the width of the entire bounds
                consumedWidth = bounds.Width;
            }

            // And the actual frame width needs to subtract the margins
            double frameWidth = Math.Max(0, consumedWidth - margin.HorizontalThickness);

            // We need to determine the height the element wants to consume; normally that's the element's DesiredSize.Height
            double consumedHeight = view.DesiredSize.Height;

            // But, if the element is set to fill vertically and it doesn't have an explicitly set height,
            // then we want the height of the entire bounds
            if (view.VerticalAlignment == VerticalAlignment.Stretch && !IsExplicitSet(view.Height))
            {
                consumedHeight = bounds.Height;
            }

            // And the actual frame height needs to subtract the margins
            double frameHeight = Math.Max(0, consumedHeight - margin.VerticalThickness);

            double frameX = AlignHorizontal(view, bounds, margin);
            double frameY = AlignVertical(view, bounds, margin);

            return new Rect(frameX, frameY, frameWidth, frameHeight);
        }

        static double AlignHorizontal(IUIElement view, Rect bounds, Thickness margin)
        {
            var alignment = view.HorizontalAlignment;

            if (alignment == HorizontalAlignment.Stretch && IsExplicitSet(view.Width))
            {
                // If the view has an explicit width set and the layout alignment is Fill,
                // we just treat the view as centered within the space it "fills"
                alignment = HorizontalAlignment.Center;
            }

            double desiredWidth = view.DesiredSize.Width;

            return AlignHorizontal(bounds.X, margin.Left, margin.Right, bounds.Width, desiredWidth, alignment);
        }

        static double AlignHorizontal(double startX, double startMargin, double endMargin, double boundsWidth,
            double desiredWidth, HorizontalAlignment horizontalLayoutAlignment)
        {
            double frameX = startX + startMargin;

            switch (horizontalLayoutAlignment)
            {
                case HorizontalAlignment.Center:
                    frameX += (boundsWidth - desiredWidth) / 2;
                    break;

                case HorizontalAlignment.Right:
                    frameX += boundsWidth - desiredWidth;
                    break;
            }

            return frameX;
        }

        static double AlignVertical(IUIElement view, Rect bounds, Thickness margin)
        {
            var alignment = view.VerticalAlignment;

            if (alignment == VerticalAlignment.Stretch && IsExplicitSet(view.Height))
            {
                // If the view has an explicit height set and the layout alignment is Fill,
                // we just treat the view as centered within the space it "fills"
                alignment = VerticalAlignment.Center;
            }

            double frameY = bounds.Y + margin.Top;

            switch (alignment)
            {
                case VerticalAlignment.Center:
                    frameY += (bounds.Height - view.DesiredSize.Height) / 2;
                    break;

                case VerticalAlignment.Bottom:
                    frameY += bounds.Height - view.DesiredSize.Height;
                    break;
            }

            return frameY;
        }

        public static Size AdjustForFill(this Size size, Rect bounds, IUIElement view)
        {
            double newWidth = size.Width;
            double newHeight = size.Height;

            if (view.HorizontalAlignment == HorizontalAlignment.Stretch)
            {
                newWidth = Math.Max(bounds.Width, newWidth);
            }

            if (view.VerticalAlignment == VerticalAlignment.Stretch)
            {
                newHeight = Math.Max(bounds.Height, newHeight);
            }

            return new Size(newWidth, newHeight);
        }
    }
}
