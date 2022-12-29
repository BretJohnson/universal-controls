namespace Microsoft.StandardUI.Controls
{
    public class CanvasLayoutManager : LayoutManager<ICanvas>
    {
        public static CanvasLayoutManager Instance = new CanvasLayoutManager();

        public override Size MeasureOverride(ICanvas canvas, double widthConstraint, double heightConstraint)
        {
            Size childConstraint = new Size(double.PositiveInfinity, double.PositiveInfinity);

            foreach (IUIElement child in canvas.Children)
            {
                if (child == null)
                    continue;
                child.Measure(childConstraint);
            }

            return new Size();
        }

        public override Size ArrangeOverride(ICanvas canvas, Size arrangeSize)
        {
            //Canvas arranges children at their DesiredSize.
            //This means that Margin on children is actually respected and added
            //to the size of layout partition for a child. 
            //Therefore, is Margin is 10 and Left is 20, the child's ink will start at 30.

            foreach (IUIElement child in canvas.Children)
            {
                if (child == null)
                    continue;

                double x = 0;
                double y = 0;

                //Compute offset of the child:
                //If Left is specified, then Right is ignored
                //If Left is not specified, then Right is used
                //If both are not there, then 0
                double left = child.CanvasLeft();
                if (!double.IsNaN(left))
                    x = left;

                double top = child.CanvasTop();
                if (!double.IsNaN(top))
                    y = top;

                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
            }
            return arrangeSize;
        }
    }
}
