// This file is generated from IStack.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Blazor.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly UIProperty OrientationProperty = new UIProperty(nameof(Orientation), Orientation.Vertical);
        
        [Parameter]
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
