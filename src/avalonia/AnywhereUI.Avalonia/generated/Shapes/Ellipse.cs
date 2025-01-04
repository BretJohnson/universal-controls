// This file is generated from IEllipse.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Shapes;
using AnywhereUI.VisualFramework;

namespace AnywhereUIAvalonia.Shapes
{
    public class Ellipse : Shape, IEllipse, IDrawable
    {
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawEllipse(this);
    }
}
