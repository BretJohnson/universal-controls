// This file is generated from IEllipse.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Shapes;

namespace AnywhereControlsAvalonia.Shapes
{
    public class Ellipse : Shape, IEllipse, IDrawable
    {
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawEllipse(this);
    }
}
