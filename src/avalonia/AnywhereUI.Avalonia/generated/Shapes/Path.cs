// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using AnywhereUI.VisualFramework;
using AnywhereUIAvalonia.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Shapes
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
