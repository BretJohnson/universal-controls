namespace Microsoft.StandardUI
{
    public interface IHostFramework
    {
        IVisualFramework VisualFramework { get; }

        IStandardUIFactory Factory { get; }
    }
}
