using CommonUI;

namespace AnywhereControls.Controls
{
    public class HorizontalStackLayoutManager : StackBaseLayoutManager<IHorizontalStack>
    {
        public static HorizontalStackLayoutManager Instance = new HorizontalStackLayoutManager();

        public override Size MeasureOverride(IHorizontalStack stack, double widthConstraint, double heightConstraint)
        {
            return MeasureOverrideHorizontal(stack, widthConstraint, heightConstraint);
        }

        public override Size ArrangeOverride(IHorizontalStack stack, Size finalSize)
        {
            return ArrangeOverrideHorizontal(stack, finalSize);
        }
    }
}
