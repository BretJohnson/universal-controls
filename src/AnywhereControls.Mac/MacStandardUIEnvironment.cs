namespace Microsoft.StandardUI.Mac
{
    public class MacStandardUIEnvironment : IStandardUIEnvironment
    {
        private readonly StandardUIFactory _uiElementFactory = new StandardUIFactory();
        private readonly IVisualEnvironment _visualEnvironment;

        public static void Init(IVisualEnvironment visualEnvironment)
        {
            StandardUIEnvironment.Init(new MacStandardUIEnvironment(visualEnvironment));
        }

        public MacStandardUIEnvironment(IVisualEnvironment visualEnvironment)
        {
            _visualEnvironment = visualEnvironment;
        }

        public IVisualEnvironment VisualEnvironment => _visualEnvironment;

        public IStandardUIFactory Factory => _uiElementFactory;
    }
}
