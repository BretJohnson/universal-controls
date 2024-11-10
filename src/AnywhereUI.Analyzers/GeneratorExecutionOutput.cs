using System.IO;
using Microsoft.CodeAnalysis;
using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.SourceGenerator
{
    public class GeneratorExecutionOutput : Output
    {
        public SourceProductionContext SourceProductionContext { get; }

        public GeneratorExecutionOutput(SourceProductionContext sourceProductionContext)
        {
            SourceProductionContext = sourceProductionContext;
        }

        public override void AddSource(UIFramework? uiFramework, string? namespaceName, string fileName, Source source)
        {
            using (var stringWriter = new StringWriter())
            {
                source.Write(stringWriter);
                string sourceFileContents = stringWriter.ToString();
                SourceProductionContext.AddSource(fileName + ".cs", sourceFileContents);
            }
        }
    }
}
