// This file is generated from IStack.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;
using Microsoft.Maui.Graphics;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace Microsoft.StandardUI.Maui.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly BindableProperty OrientationProperty = PropertyUtils.Register(nameof(Orientation), typeof(Orientation), typeof(Stack), Orientation.Vertical);
        
        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            StackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            StackLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
