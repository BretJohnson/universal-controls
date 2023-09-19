// This file is generated from IStack.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly Avalonia.StyledProperty<Orientation> OrientationProperty = AvaloniaProperty.Register<Stack, Orientation>(nameof(Orientation), Orientation.Vertical);
        
        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        
        protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>
            StackLayoutManager.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();
        
        protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>
            StackLayoutManager.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();
    }
}
