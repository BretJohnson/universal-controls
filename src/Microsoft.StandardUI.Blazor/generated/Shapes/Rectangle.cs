// This file is generated from IRectangle.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI.Blazor.Shapes
{
    public class Rectangle : Shape, IRectangle
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

        public override void Draw(IDrawingContext drawingContext) => drawingContext.DrawRectangle(this);
    }
}
