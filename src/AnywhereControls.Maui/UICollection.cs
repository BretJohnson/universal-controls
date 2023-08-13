using Microsoft.Maui.Controls;

namespace AnywhereControls.Maui
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
