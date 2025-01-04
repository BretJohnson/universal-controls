namespace AnywhereUI.Controls;

public interface IAnywhereControl : IUIElement
{
    IUIElement? Content { get; }
}
