using System.Collections.Generic;

namespace AnywhereUI
{
    public interface IUICollection<T> : IList<T>
    {
        void Set(params T[] items);
    }
}
