// This file is generated from ILine.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI.Blazor.Shapes
{
    public class Line : Shape, ILine, IDrawable
    {
        public static readonly UIProperty X1Property = new UIProperty(nameof(X1), 0.0);
        public static readonly UIProperty Y1Property = new UIProperty(nameof(Y1), 0.0);
        public static readonly UIProperty X2Property = new UIProperty(nameof(X2), 0.0);
        public static readonly UIProperty Y2Property = new UIProperty(nameof(Y2), 0.0);
        
        [Parameter]
        public double X1
        {
            get => (double) GetNonNullValue(X1Property);
            set => SetValue(X1Property, value);
        }
        
        [Parameter]
        public double Y1
        {
            get => (double) GetNonNullValue(Y1Property);
            set => SetValue(Y1Property, value);
        }
        
        [Parameter]
        public double X2
        {
            get => (double) GetNonNullValue(X2Property);
            set => SetValue(X2Property, value);
        }
        
        [Parameter]
        public double Y2
        {
            get => (double) GetNonNullValue(Y2Property);
            set => SetValue(Y2Property, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawLine(this);
    }
}
