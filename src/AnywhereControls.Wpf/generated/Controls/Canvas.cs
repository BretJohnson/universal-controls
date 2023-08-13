// This file is generated from ICanvas.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;
using ICanvas = Microsoft.StandardUI.Controls.ICanvas;
using DependencyProperty = System.Windows.DependencyProperty;

namespace Microsoft.StandardUI.Wpf.Controls
{
    public class Canvas : Panel, ICanvas
    {
        public static readonly DependencyProperty LeftProperty = PropertyUtils.RegisterAttached("Left", typeof(double), typeof(System.Windows.UIElement), 0.0);
        public static readonly DependencyProperty TopProperty = PropertyUtils.RegisterAttached("Top", typeof(double), typeof(System.Windows.UIElement), 0.0);
        
        public static double GetLeft(System.Windows.UIElement element) => (double) element.GetValue(LeftProperty);
        public static void SetLeft(System.Windows.UIElement element, double value) => element.SetValue(LeftProperty, value);
        
        public static double GetTop(System.Windows.UIElement element) => (double) element.GetValue(TopProperty);
        public static void SetTop(System.Windows.UIElement element, double value) => element.SetValue(TopProperty, value);
        
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>
            CanvasLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToWpfSize();
        
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize) =>
            CanvasLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToStandardUISize()).ToWpfSize();
    }
}
