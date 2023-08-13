// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.WinUI.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, constraint.ToStandardUISize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToStandardUISize()).ToWindowsFoundationSize();
    }
}
