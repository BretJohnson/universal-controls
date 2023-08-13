namespace Microsoft.StandardUI.Blazor
{
    internal sealed class ParentingInfo<TUIElement>
        where TUIElement : IUIElement
    {
        public readonly UIElement Parent;
        public readonly UIElementCollection<TUIElement> Children;

        public ParentingInfo(UIElement parent, UIElementCollection<TUIElement> children)
        {
            Parent = parent;
            Children = children;
        }
    }
}
