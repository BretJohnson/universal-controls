using System.Collections.Generic;

namespace UniversalUI
{
    public interface IUICollection<T> : IList<T>
    {
        void Set(params T[] items);
    }
}
