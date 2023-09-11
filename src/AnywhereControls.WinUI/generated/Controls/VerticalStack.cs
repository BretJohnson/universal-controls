// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.WinUI.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, constraint.ToAnywhereControlsSize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToWindowsFoundationSize();
    }
}
