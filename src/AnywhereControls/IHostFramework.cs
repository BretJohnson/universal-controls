namespace AnywhereControls
{
    public interface IHostFramework
    {
        IVisualFramework VisualFramework { get; }

        IStandardUIFactory Factory { get; }
    }
}
