// This file is generated from IPath.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;
using UniversalUI.WinForms.Media;
using UniversalUI.Shapes;

namespace AnywhereControls.WinForms.Shapes
{
    public class Path : Shape, IPath, IDrawable
    {
        public static readonly UIProperty DataProperty = new UIProperty(nameof(Data), null);
        
        public IGeometry Data
        {
            get => (Geometry) GetNonNullValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPath(this);
    }
}
