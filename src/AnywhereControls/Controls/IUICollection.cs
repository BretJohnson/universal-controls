using System.Collections.Generic;

namespace Microsoft.StandardUI
{
    public interface IUICollection<T> : IList<T>
    {
        void Set(params T[] items);
    }
}
