using AnywhereUI.SourceGenerator.UIFrameworks;

namespace AnywhereUI.SourceGenerator
{
    public abstract class Output
    {
        public abstract void AddSource(UIFramework? uiFramework, string? namespaceName, string fileName, Source source);
    }
}
