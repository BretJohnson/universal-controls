namespace AnywhereControls.SourceGenerator.UIFrameworks
{
    public class UIFrameworkType
    {
        private readonly UIFrameworkCreator _uiFrameworkCreator;

        public delegate UIFramework UIFrameworkCreator(Context context);

        public UIFrameworkType(UIFrameworkCreator uiFrameworkCreator)
        {
            _uiFrameworkCreator = uiFrameworkCreator;
        }

        public UIFramework CreateUIFramework(Context context) => _uiFrameworkCreator(context);

        public static UIFrameworkType Wpf = new((Context context) => new WpfUIFramework(context));
        public static UIFrameworkType Mac = new((Context context) => new MacUIFramework(context));
        public static UIFrameworkType Maui = new((Context context) => new MauiUIFramework(context));
        public static UIFrameworkType WinUI = new((Context context) => new WinUIUIFramework(context));
        public static UIFrameworkType WinForms = new((Context context) => new WinFormsUIFramework(context));
        public static UIFrameworkType Blazor = new((Context context) => new BlazorUIFramework(context));
    }
}
