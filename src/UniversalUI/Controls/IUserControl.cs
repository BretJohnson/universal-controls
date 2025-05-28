namespace UniversalUI.Controls
{
    public interface IUserControl : IUniversalControl
    {
        public IUIElement? Content { get; set; }
    }
}
