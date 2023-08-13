namespace AnywhereControls.WinForms
{
    public class WinFormsHostFramework : IHostFramework
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new WinFormsHostFramework(visualFramework));
        }

        public WinFormsHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IStandardUIFactory Factory => _uiElementFactory;
    }
}
