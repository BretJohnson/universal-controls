// This file is generated from ICanvas.cs. Update the source file to change its contents.

using UniversalUI.Controls;
using ICanvas = AnywhereControls.Controls.ICanvas;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Controls
{
    public class Canvas : Panel, ICanvas
    {
        public static readonly DependencyProperty LeftProperty = PropertyUtils.RegisterAttached("Left", typeof(double), typeof(Microsoft.UI.Xaml.FrameworkElement), 0.0);
        public static readonly DependencyProperty TopProperty = PropertyUtils.RegisterAttached("Top", typeof(double), typeof(Microsoft.UI.Xaml.FrameworkElement), 0.0);
        
        public static double GetLeft(Microsoft.UI.Xaml.FrameworkElement element) => (double) element.GetValue(LeftProperty);
        public static void SetLeft(Microsoft.UI.Xaml.FrameworkElement element, double value) => element.SetValue(LeftProperty, value);
        
        public static double GetTop(Microsoft.UI.Xaml.FrameworkElement element) => (double) element.GetValue(TopProperty);
        public static void SetTop(Microsoft.UI.Xaml.FrameworkElement element, double value) => element.SetValue(TopProperty, value);
        
        protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size constraint) =>
            CanvasLayoutManager.Instance.MeasureOverride(this, constraint.ToAnywhereControlsSize()).ToWindowsFoundationSize();
        
        protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size arrangeSize) =>
            CanvasLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToAnywhereControlsSize()).ToWindowsFoundationSize();
    }
}
