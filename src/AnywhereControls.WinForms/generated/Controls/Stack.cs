// This file is generated from IStack.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using AnywhereControls.Controls;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.WinForms.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly UIProperty OrientationProperty = new UIProperty(nameof(Orientation), Orientation.Vertical);
        
        public Orientation Orientation
        {
            get => (Orientation) GetNonNullValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            StackLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            StackLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
