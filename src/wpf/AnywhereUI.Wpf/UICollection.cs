using System.Windows;

namespace AnywhereControls.Wpf
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
