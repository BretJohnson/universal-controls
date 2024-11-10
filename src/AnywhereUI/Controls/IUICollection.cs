using System.Collections.Generic;

namespace AnywhereControls
{
    public interface IUICollection<T> : IList<T>
    {
        void Set(params T[] items);
    }
}
