using System.ComponentModel;
using UniversalUI.Media;

namespace UniversalUI.Shapes
{
    [UIModelObject]
    public interface IPath : IShape
    {
        [DefaultValue(null)]
        IGeometry Data { get; set; }
    }
}
