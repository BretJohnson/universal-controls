namespace UniversalUI.Wpf
{
    public interface ILogicalParent
    {
        void AddLogicalChild(object child);

        void RemoveLogicalChild(object child);
    }
}
