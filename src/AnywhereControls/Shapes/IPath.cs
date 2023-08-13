using System.ComponentModel;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Shapes
{
    [UIModelObject]
    public interface IPath : IShape
    {
        [DefaultValue(null)]
        IGeometry Data { get; set; }
    }
}
