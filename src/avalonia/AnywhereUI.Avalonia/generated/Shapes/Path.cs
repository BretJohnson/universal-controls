// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AnywhereControlsAvalonia.Media;
using AnywhereControls.Shapes;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Shapes
{
    public class Path : Shape, IPath, IDrawable
    {
        public static readonly Avalonia.StyledProperty<Geometry> DataProperty = AvaloniaProperty.Register<Path, Geometry>(nameof(Data), null);
        
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
