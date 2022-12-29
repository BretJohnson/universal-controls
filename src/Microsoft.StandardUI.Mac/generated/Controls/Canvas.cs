// This file is generated from ICanvas.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Mac.Controls
{
    public class Canvas : Panel, ICanvas
    {
        public static readonly AttachedUIProperty LeftProperty = new AttachedUIProperty("Left", 0.0);
        public static readonly AttachedUIProperty TopProperty = new AttachedUIProperty("Top", 0.0);
        
        public static double GetLeft(StandardUIElement element) => (double) AttachedPropertiesValues.GetValue(element, LeftProperty);
        public static void SetLeft(StandardUIElement element, double value) => AttachedPropertiesValues.SetValue(element, LeftProperty, value);
        
        public static double GetTop(StandardUIElement element) => (double) AttachedPropertiesValues.GetValue(element, TopProperty);
        public static void SetTop(StandardUIElement element, double value) => AttachedPropertiesValues.SetValue(element, TopProperty, value);
        
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            CanvasLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            CanvasLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
