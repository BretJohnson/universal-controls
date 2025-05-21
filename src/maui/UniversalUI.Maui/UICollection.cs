using Microsoft.Maui.Controls;

namespace UniversalUI.Maui
{
    public sealed class UICollection<T> : BasicUICollection<T>
    {
        BindableObject _parent;

        public UICollection(BindableObject parent)
        {
            _parent = parent;
        }
    }
}
