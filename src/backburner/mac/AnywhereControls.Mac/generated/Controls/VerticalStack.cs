// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using CommonUI;
using UniversalUI.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
