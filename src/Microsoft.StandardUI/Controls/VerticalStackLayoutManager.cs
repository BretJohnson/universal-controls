namespace Microsoft.StandardUI.Controls
{
    public class VerticalStackLayoutManager : StackBaseLayoutManager<IVerticalStack>
    {
        public static VerticalStackLayoutManager Instance = new VerticalStackLayoutManager();

        public override Size MeasureOverride(IVerticalStack stack, double widthConstraint, double heightConstraint)
        {
            return MeasureOverrideVertical(stack, widthConstraint, heightConstraint);
        }

        public override Size ArrangeOverride(IVerticalStack stack, Size finalSize)
        {
            return ArrangeOverrideVertical(stack, finalSize);
        }
    }
}
