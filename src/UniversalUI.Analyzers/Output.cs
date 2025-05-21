using UniversalUI.SourceGenerator.UIFrameworks;

namespace UniversalUI.SourceGenerator
{
    public abstract class Output
    {
        public abstract void AddSource(UIFramework? uiFramework, string? namespaceName, string fileName, Source source);
    }
}
