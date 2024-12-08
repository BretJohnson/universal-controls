// This file is generated from IEllipse.cs. Update the source file to change its contents.

using AnywhereUI.Shapes;

namespace AnywhereControls.WinUI.Shapes
{
    public class Ellipse : Shape, IEllipse, IDrawable
    {
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawEllipse(this);
    }
}
