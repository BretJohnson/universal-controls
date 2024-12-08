// This file is generated from IRectangle.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using AnywhereUI.Shapes;

namespace AnywhereControls.Blazor.Shapes
{
    public class Rectangle : Shape, IRectangle, IDrawable
    {
        public static readonly UIProperty RadiusXProperty = new UIProperty(nameof(RadiusX), 0.0);
        public static readonly UIProperty RadiusYProperty = new UIProperty(nameof(RadiusY), 0.0);
        
        [Parameter]
        public double RadiusX
        {
            get => (double) GetNonNullValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
        
        [Parameter]
        public double RadiusY
        {
            get => (double) GetNonNullValue(RadiusYProperty);
            set => SetValue(RadiusYProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawRectangle(this);
    }
}
