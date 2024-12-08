namespace AnywhereUI.Controls
{
    public class StackLayoutManager : StackBaseLayoutManager<IStack>
    {
        public static StackLayoutManager Instance = new StackLayoutManager();

        public override Size MeasureOverride(IStack stack, double widthConstraint, double heightConstraint)
        {
            return stack.Orientation == Orientation.Horizontal ?
                MeasureOverrideHorizontal(stack, widthConstraint, heightConstraint) :
                MeasureOverrideVertical(stack, widthConstraint, heightConstraint);
        }

        public override Size ArrangeOverride(IStack stack, Size finalSize)
        {
            return stack.Orientation == Orientation.Horizontal ?
                ArrangeOverrideHorizontal(stack, finalSize) :
                ArrangeOverrideVertical(stack, finalSize);
        }
    }
}
