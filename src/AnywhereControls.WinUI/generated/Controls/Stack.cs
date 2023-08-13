// This file is generated from IStack.cs. Update the source file to change its contents.

using AnywhereControls.Controls;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Controls
{
    public class Stack : StackBase, IStack
    {
        public static readonly DependencyProperty OrientationProperty = PropertyUtils.Register(nameof(Orientation), typeof(Orientation), typeof(Stack), Orientation.Vertical);
        
        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            StackLayoutManager.Instance.MeasureOverride(this, constraint.ToStandardUISize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            StackLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToStandardUISize()).ToWindowsFoundationSize();
    }
}
