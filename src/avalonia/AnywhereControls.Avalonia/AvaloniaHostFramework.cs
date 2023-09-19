using AnywhereControls;

namespace AnywhereControlsAvalonia
{
    public class AvaloniaHostFramework : IHostFramework
    {
        private readonly AnywhereControlsUIFactory _uiElementFactory = new AnywhereControlsUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new AvaloniaHostFramework(visualFramework));
        }

        public AvaloniaHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IAnywhereControlsUIFactory Factory => _uiElementFactory;
    }
}
