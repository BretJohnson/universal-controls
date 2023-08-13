namespace Microsoft.StandardUI.Controls
{
    public interface IUserControl : IStandardControl
    {
        public IUIElement? Content { get; set; }
    }
}
