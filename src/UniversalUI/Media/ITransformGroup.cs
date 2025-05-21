using System.Collections.Generic;

namespace UniversalUI.Media
{
    [UIModelObject]
    public interface ITransformGroup : ITransform
    {
        IEnumerable<ITransform> Children { get; }
    }
}
