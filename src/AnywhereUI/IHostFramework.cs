using AnywhereUI.VisualFramework;

namespace AnywhereUI
{
    public interface IHostFramework
    {
        IVisualFramework VisualFramework { get; }

        IAnywhereControlsUIFactory Factory { get; }
    }
}
