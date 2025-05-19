namespace AnywhereUI.DefaultImplementations
{
    public class AttachedUIProperty : UIProperty
    {
        public AttachedUIProperty(string name, object? defaultValue, bool readOnly = false)
            : base(name, defaultValue, readOnly)
        {
        }
    }
}
