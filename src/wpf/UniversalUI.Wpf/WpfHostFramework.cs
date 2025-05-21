namespace UniversalUI.Wpf
{
    public class WpfHostFramework : IHostFramework
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new WpfHostFramework(visualFramework));
        }

        public WpfHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IAnywhereControlsUIFactory Factory => _uiElementFactory;
    }
}
