namespace Microsoft.StandardUI.Mac
{
    public sealed class UIElementCollection<TStandardUIElement> : BasicUICollection<TStandardUIElement>
        where TStandardUIElement : IUIElement
    {
        public UIElementCollection(StandardUIElement parent)
        {
        }

        public IUICollection<TStandardUIElement> ToStandardUIElementCollection() => this;
    }
}
