using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.SourceGenerator
{
    public abstract class Output
    {
        public abstract void AddSource(UIFramework? uiFramework, string? namespaceName, string fileName, Source source);
    }
}
