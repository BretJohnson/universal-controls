using System.ComponentModel;
using AnywhereUI.Media;

namespace AnywhereUI.Shapes
{
    [UIModelObject]
    public interface IPath : IShape
    {
        [DefaultValue(null)]
        IGeometry Data { get; set; }
    }
}
