// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.Maui.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override Microsoft.Maui.Graphics.Size MeasureOverride(Microsoft.Maui.Graphics.Size constraint) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToMauiSize();
        
        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Size arrangeSize) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToMauiSize();
    }
}
