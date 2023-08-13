using Microsoft.ComponentModelEx;

namespace Microsoft.StandardUI.Controls
{
    [UIModelObject]
    [ContentProperty(nameof(Children))]
    public interface IPanel : IUIElement
    {
        IUICollection<IUIElement> Children { get; }
    }
}
