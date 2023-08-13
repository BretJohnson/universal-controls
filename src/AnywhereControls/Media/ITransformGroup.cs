using System.Collections.Generic;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface ITransformGroup : ITransform
    {
        IEnumerable<ITransform> Children { get; }
    }
}
