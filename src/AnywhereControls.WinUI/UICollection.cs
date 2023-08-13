using Microsoft.UI.Xaml;

namespace Microsoft.StandardUI.WinUI
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
