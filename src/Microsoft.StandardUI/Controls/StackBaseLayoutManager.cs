using System;

namespace Microsoft.StandardUI.Controls
{
    public abstract class StackBaseLayoutManager<TStack> : LayoutManager<TStack> where TStack : IStackBase
    {
        public Size MeasureOverrideHorizontal(IStackBase stack, double widthConstraint, double heightConstraint)
        {
            //var padding = panelStack.Padding;

            double measuredWidth = 0;
            double measuredHeight = 0;

            IUICollection<IUIElement> children = stack.Children;
            int count = stack.Children.Count;
            for (int i = 0; i < count; i++)
            {
                IUIElement child = children[i];
                if (!child.Visible)
                {
                    continue;
                }

                child.Measure(double.PositiveInfinity, heightConstraint);
                var desiredSize = child.DesiredSize;
                measuredWidth += desiredSize.Width;
                measuredHeight = Math.Max(measuredHeight, desiredSize.Height);
            }

            measuredWidth += MeasureTotalSpacing(stack);
            //measuredWidth += padding.HorizontalThickness;
            //measuredHeight += padding.VerticalThickness;

            var finalWidth = ResolveWidthConstraints(stack, widthConstraint, measuredWidth);
            var finalHeight = ResolveHeightConstraints(stack, heightConstraint, measuredHeight);

            return new Size(finalWidth, finalHeight);
        }

        public Size MeasureOverrideVertical(IStackBase stack, double widthConstraint, double heightConstraint)
        {
            //var padding = panelStack.Padding;

            double measuredHeight = 0;
            double measuredWidth = 0;

            IUICollection<IUIElement> children = stack.Children;
            int count = stack.Children.Count;
            for (int i = 0; i < count; i++)
            {
                IUIElement child = children[i];
                if (!child.Visible)
                {
                    continue;
                }

                child.Measure(widthConstraint, double.PositiveInfinity);
                var desiredSize = child.DesiredSize;
                measuredHeight += desiredSize.Height;
                measuredWidth = Math.Max(measuredWidth, desiredSize.Width);
            }

            measuredWidth += MeasureTotalSpacing(stack);
            //measuredWidth += padding.HorizontalThickness;
            //measuredHeight += padding.VerticalThickness;

            var finalHeight = ResolveHeightConstraints(stack, heightConstraint, measuredHeight);
            var finalWidth = ResolveWidthConstraints(stack, widthConstraint, measuredWidth);

            return new Size(finalWidth, finalHeight);
        }

        protected static double MeasureTotalSpacing(IStackBase stack)
        {
            int childCount = stack.Children.Count;
            return childCount > 1 ? (childCount - 1) * stack.Spacing : 0;
        }

        protected static Size ArrangeOverrideHorizontal(IStackBase stack, Size finalSize)
        {
            //var padding = Stack.Padding;
            //double top = padding.Top + bounds.Top;
            //double left = padding.Left + bounds.Left;
            //var height = bounds.Height - padding.VerticalThickness;

            var children = stack.Children;
            int count = children.Count;
            double height = finalSize.Height;
            double spacing = stack.Spacing;

            double xPosition = 0;
            if (stack.FlowDirection == FlowDirection.LeftToRight)
            {
                for (int n = 0; n < count; n++)
                {
                    IUIElement child = children[n];
                    if (!child.Visible)
                    {
                        continue;
                    }

                    double childWidth = child.DesiredSize.Width;
                    child.Arrange(new Rect(xPosition, 0, childWidth, height));
                    xPosition += childWidth + spacing;
                }
            }
            else
            {
                for (int n = count - 1; n >= 0; n--)
                {
                    IUIElement child = children[n];
                    if (!child.Visible)
                    {
                        continue;
                    }

                    double childWidth = child.DesiredSize.Width;
                    child.Arrange(new Rect(xPosition, 0, childWidth, height));
                    xPosition += childWidth + spacing;
                }
            }

            return AdjustForStretchToFill(stack, xPosition, height, finalSize);
        }

        protected static Size ArrangeOverrideVertical(IStackBase stack, Size finalSize)
        {
            //var padding = Stack.Padding;
            //double top = padding.Top + bounds.Top;
            //double left = padding.Left + bounds.Left;
            //var height = bounds.Height - padding.VerticalThickness;

            var children = stack.Children;
            int count = children.Count;
            double width = finalSize.Width;
            double spacing = stack.Spacing;

            double stackHeight = 0;
            for (int n = 0; n < count; n++)
            {
                IUIElement child = children[n];

                if (!child.Visible)
                {
                    continue;
                }

                double childHeight = child.DesiredSize.Height;
                child.Arrange(new Rect(0, stackHeight, width, childHeight));
                stackHeight += childHeight + spacing;
            }

            return AdjustForStretchToFill(stack, width, stackHeight, finalSize);
        }
    }
}
