// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Blazor.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
