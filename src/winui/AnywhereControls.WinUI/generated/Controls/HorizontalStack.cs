// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.WinUI.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, constraint.ToAnywhereControlsSize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToWindowsFoundationSize();
    }
}
