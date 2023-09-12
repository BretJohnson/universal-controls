namespace AnywhereControls.Blazor
{
    public class BlazorHostFramework : IHostFramework
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualFramework _visualFramework;

        public static void Init(IVisualFramework visualFramework)
        {
            HostEnvironment.Init(new BlazorHostFramework(visualFramework));
        }

        public BlazorHostFramework(IVisualFramework visualFramework)
        {
            _visualFramework = visualFramework;
        }

        public IVisualFramework VisualFramework => _visualFramework;

        public IAnywhereControlsUIFactory Factory => _uiElementFactory;
    }
}
