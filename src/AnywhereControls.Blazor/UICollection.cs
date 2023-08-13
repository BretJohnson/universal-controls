namespace Microsoft.StandardUI.Blazor
{
    public sealed class UICollection<T> : BasicUICollection<T>
    {
        object _parent;

        public UICollection(object parent)
        {
            _parent = parent;
        }
    }
}
