using System.IO;
using UniversalUI.SourceGenerator.UIFrameworks;

namespace UniversalUI.SourceGenerator
{
    public class DirectoryOutput : Output
    {
        public string RootDirectory { get; }

        public DirectoryOutput(string rootDirectory)
        {
            RootDirectory = rootDirectory;
        }

        public override void AddSource(UIFramework? uiFramework, string? namespaceName, string fileName, Source source)
        {
            string outputDirectory = uiFramework != null
                ? Path.Combine(RootDirectory, "src", uiFramework.Name.ToLower(), uiFramework.ProjectBaseDirectory, "generated")
                : Path.Combine(RootDirectory, "src", "UniversalUI", "generated");

            if (namespaceName != null)
            {
                string? childNamespaceName = Utils.GetChildNamespaceName(namespaceName, uiFramework);
                if (childNamespaceName != null)
                    outputDirectory = Path.Combine(outputDirectory, childNamespaceName);
            }

            source.WriteToFile(outputDirectory, fileName + ".cs");
        }
    }
}
