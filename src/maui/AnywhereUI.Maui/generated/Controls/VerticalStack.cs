// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereUI.Maui.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override Microsoft.Maui.Graphics.Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint).ToMauiSize();
        
        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Rect bounds) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, bounds.Size.ToAnywhereControlsSize()).ToMauiSize();
    }
}
