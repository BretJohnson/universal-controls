// This file is generated from ICanvas.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.Maui.Graphics;
using AnywhereControls.Controls;
using ICanvas = AnywhereControls.Controls.ICanvas;

namespace AnywhereControls.Blazor.Controls
{
    public class Canvas : Panel, ICanvas
    {
        public static readonly AttachedUIProperty LeftProperty = new AttachedUIProperty("Left", 0.0);
        public static readonly AttachedUIProperty TopProperty = new AttachedUIProperty("Top", 0.0);
        
        public static double GetLeft(Microsoft.AspNetCore.Components.ComponentBase element) => (double) AttachedPropertiesValues.GetValue(element, LeftProperty);
        public static void SetLeft(Microsoft.AspNetCore.Components.ComponentBase element, double value) => AttachedPropertiesValues.SetValue(element, LeftProperty, value);
        
        public static double GetTop(Microsoft.AspNetCore.Components.ComponentBase element) => (double) AttachedPropertiesValues.GetValue(element, TopProperty);
        public static void SetTop(Microsoft.AspNetCore.Components.ComponentBase element, double value) => AttachedPropertiesValues.SetValue(element, TopProperty, value);
        
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            CanvasLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            CanvasLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}
