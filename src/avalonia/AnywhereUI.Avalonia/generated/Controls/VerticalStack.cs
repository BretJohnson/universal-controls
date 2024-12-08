// This file is generated from IVerticalStack.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereControlsAvalonia.Controls
{
    public class VerticalStack : StackBase, IVerticalStack
    {
        protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>
            VerticalStackLayoutManager.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();
        
        protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>
            VerticalStackLayoutManager.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();
    }
}
