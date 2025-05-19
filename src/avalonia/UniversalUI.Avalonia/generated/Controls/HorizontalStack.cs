// This file is generated from IHorizontalStack.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereControlsAvalonia.Controls
{
    public class HorizontalStack : StackBase, IHorizontalStack
    {
        protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>
            HorizontalStackLayoutManager.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();
        
        protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>
            HorizontalStackLayoutManager.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();
    }
}
