using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.StandardUI.SourceGenerator.UIFrameworks;

namespace Microsoft.StandardUI.SourceGenerator
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
