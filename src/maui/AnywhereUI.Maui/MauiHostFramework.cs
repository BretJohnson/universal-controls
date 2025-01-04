using AnywhereUI.VisualFramework;

namespace AnywhereUI.Maui
{
    public class MauiHostFramework : IHostFramework
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new MauiHostFramework(visualFramework));
        }

        public MauiHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IAnywhereControlsUIFactory Factory => _uiElementFactory;
    }
}
