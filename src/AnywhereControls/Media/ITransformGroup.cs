using System.Collections.Generic;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ITransformGroup : ITransform
    {
        IEnumerable<ITransform> Children { get; }
    }
}
