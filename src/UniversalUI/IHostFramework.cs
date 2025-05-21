namespace UniversalUI
{
    public interface IHostFramework
    {
        IVisualFramework VisualFramework { get; }

        IAnywhereControlsUIFactory Factory { get; }
    }
}
