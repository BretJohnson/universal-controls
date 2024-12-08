// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using AnywhereUI.Maui.Media;
using AnywhereUI.Shapes;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereUI.Maui.Shapes
{
    public class Path : Shape, IPath, IDrawable
    {
        public static readonly BindableProperty DataProperty = PropertyUtils.Register(nameof(Data), typeof(Geometry), typeof(Path), null);
        
        public Geometry Data
        {
            get => (Geometry) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        IGeometry IPath.Data
        {
            get => Data;
            set => Data = (Geometry) value;
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPath(this);
    }
}
