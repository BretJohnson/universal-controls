// This file is generated from IStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly BindableProperty OrientationProperty = PropertyUtils.Register(nameof(Orientation), typeof(Orientation), typeof(Stack), Orientation.Vertical);
        
        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        
        protected override Microsoft.Maui.Graphics.Size MeasureOverride(Microsoft.Maui.Graphics.Size constraint) =>
            StackLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToMauiSize();
        
        protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Size arrangeSize) =>
            StackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToMauiSize();
    }
}
