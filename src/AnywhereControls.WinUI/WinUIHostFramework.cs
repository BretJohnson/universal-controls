namespace AnywhereControls.WinUI
{
    public class WinUIHostFramework : IHostFramework
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new WinUIHostFramework(visualFramework));
        }

        public WinUIHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IStandardUIFactory Factory => _uiElementFactory;
    }
}
