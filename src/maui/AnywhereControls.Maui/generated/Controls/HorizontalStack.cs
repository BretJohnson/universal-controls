// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.Maui.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override Microsoft.Maui.Graphics.Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint).ToMauiSize();
        
        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Rect bounds) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, bounds.Size.ToAnywhereControlsSize()).ToMauiSize();
    }
}
