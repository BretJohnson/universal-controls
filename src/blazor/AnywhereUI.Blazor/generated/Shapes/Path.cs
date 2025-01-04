// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereUI.Blazor.Media;
using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using AnywhereUI.VisualFramework;
using Microsoft.AspNetCore.Components;

namespace AnywhereUI.Blazor.Shapes
{
    public class Path : Shape, IPath, IDrawable
    {
        public static readonly UIProperty DataProperty = new UIProperty(nameof(Data), null);
        
        [Parameter]
        public IGeometry Data
        {
            get => (Geometry) GetNonNullValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPath(this);
    }
}
