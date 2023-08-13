// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.WinUI.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, constraint.ToStandardUISize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToStandardUISize()).ToWindowsFoundationSize();
    }
}
