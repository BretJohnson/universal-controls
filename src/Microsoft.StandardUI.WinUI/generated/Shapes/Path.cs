// This file is generated from IPath.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.WinUI.Media;
using Microsoft.StandardUI.Shapes;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Shapes
{
    public class Path : Shape, IPath, IDrawable
    {
        public static readonly DependencyProperty DataProperty = PropertyUtils.Register(nameof(Data), typeof(Geometry), typeof(Path), null);
        
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
