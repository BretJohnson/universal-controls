using Microsoft.UI.Xaml;

namespace AnywhereControls.WinUI
{
    public sealed class UICollection<T> : BasicUICollection<T>
    {
        DependencyObject _parent;

        public UICollection(DependencyObject parent)
        {
            _parent = parent;
        }
    }
}
