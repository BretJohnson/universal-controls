// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.Maui.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override Microsoft.Maui.Graphics.Size MeasureOverride(Microsoft.Maui.Graphics.Size constraint) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToMauiSize();
        
        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Size arrangeSize) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToMauiSize();
    }
}
