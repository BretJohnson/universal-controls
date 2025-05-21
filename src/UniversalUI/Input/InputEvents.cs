namespace UniversalUI.Input;

public static class InputEvents
{
    public static readonly RoutedEvent PointerEnteredEvent = GlobalEventManager.RegisterRoutedEvent(nameof(IUIElement.PointerEntered), RoutingStrategy.Direct, typeof(PointerEventHandler));
    public static readonly RoutedEvent PointerExitedEvent = GlobalEventManager.RegisterRoutedEvent(nameof(IUIElement.PointerExited), RoutingStrategy.Direct, typeof(PointerEventHandler));
    public static readonly RoutedEvent PointerMovedEvent = GlobalEventManager.RegisterRoutedEvent(nameof(IUIElement.PointerMoved), RoutingStrategy.Direct, typeof(PointerEventHandler));
}
