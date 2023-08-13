using System.ComponentModel;
using AnywhereControls.Media;

namespace AnywhereControls.Shapes
{
    [UIModelObject]
    public interface IPath : IShape
    {
        [DefaultValue(null)]
        IGeometry Data { get; set; }
    }
}
