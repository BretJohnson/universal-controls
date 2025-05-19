// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereUI.Wpf.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToWpfSize();
        
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToWpfSize();
    }
}
