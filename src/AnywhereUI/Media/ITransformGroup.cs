using System.Collections.Generic;

namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface ITransformGroup : ITransform
    {
        IEnumerable<ITransform> Children { get; }
    }
}
