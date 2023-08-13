namespace AnywhereControls.Blazor
{
    public sealed class UIElementCollection<TUIElement> : BasicUICollection<TUIElement>
        where TUIElement : IUIElement
    {
        public UIElementCollection(object parent)
        {
        }

        public IUICollection<TUIElement> ToStandardUIElementCollection() => this;
    }
}
