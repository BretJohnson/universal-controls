// This file is generated from IEllipse.cs. Update the source file to change its contents.

using UniversalUI.Shapes;

namespace UniversalUI.Wpf.Shapes
{
    public class Ellipse : Shape, IEllipse, IDrawable
    {
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawEllipse(this);
    }
}
