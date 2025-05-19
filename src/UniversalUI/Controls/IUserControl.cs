namespace AnywhereUI.Controls
{
    public interface IUserControl : IAnywhereControl
    {
        public IUIElement? Content { get; set; }
    }
}
