using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using AnywhereControls.SourceGenerator;
using AnywhereControls.SourceGenerator.UIFrameworks;

namespace AnywhereControls.CommandLineSourceGenerator
{
    public static class Generator
    {
        public static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine($"Usage: AnywhereControls.CodelGenerator.exe <path-to-repo-root>");
                Environment.Exit(1);
            }

            string rootDirectory = NormalizePath(args[0]);

            MSBuildLocator.RegisterDefaults();

            using MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            // Print message for WorkspaceFailed event to help diagnosing project load failures.
            workspace.WorkspaceFailed += (o, e) => Console.WriteLine(e.Diagnostic.Message);

            string standardUIProjectPath = Path.Combine(rootDirectory, "src", "AnywhereControls", "AnywhereControls.csproj");
            Console.WriteLine($"Loading project '{standardUIProjectPath}'");

            // Attach progress reporter so we print projects as they are loaded.
            Project project = await workspace.OpenProjectAsync(standardUIProjectPath, new ConsoleProgressReporter());
            Console.WriteLine($"Finished loading project '{standardUIProjectPath}'");

            try
            {
                GenerateClasses(rootDirectory, project);
            }
            catch (UserViewableException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
                Environment.Exit(2);
            }
        }

        private static void GenerateClasses(string rootDirectory, Project project)
        {
            Compilation? compilation = project.GetCompilationAsync().Result;
            if (compilation == null)
                return;

            var context = new Context(compilation, new DirectoryOutput(rootDirectory));
            var controlLibrary = new ControlLibrary(context, context.Compilation.Assembly);

            Console.WriteLine($"Generating source for these interfaces:");
            foreach (Interface intface in controlLibrary.Interfaces)
            {
                Console.WriteLine($"{intface.Name}");
            }

            controlLibrary.GenerateControlClasses(new WpfUIFramework(context));
            controlLibrary.GenerateControlClasses(new WinUIUIFramework(context));
            controlLibrary.GenerateControlClasses(new WinFormsUIFramework(context));
            controlLibrary.GenerateControlClasses(new MacUIFramework(context));
            controlLibrary.GenerateControlClasses(new MauiUIFramework(context));
            controlLibrary.GenerateControlClasses(new BlazorUIFramework(context));

            controlLibrary.GenerateExtensionsClasses();

            //controlLibrary.GenerateFactoryClass();
            //controlLibrary.GenerateStaticsClass();
        }

        private static string NormalizePath(string path)
        {
            path = path.Trim();
            try
            {
                return Path.GetFullPath(path).TrimEnd('\\').ToLowerInvariant();
            }
            catch (ArgumentException)
            {
                // If invalid path, leave unmodified
                return path;
            }
        }

        private class ConsoleProgressReporter : IProgress<ProjectLoadProgress>
        {
            public void Report(ProjectLoadProgress loadProgress)
            {
                var projectDisplay = Path.GetFileName(loadProgress.FilePath);
                if (loadProgress.TargetFramework != null)
                {
                    projectDisplay += $" ({loadProgress.TargetFramework})";
                }

                Console.WriteLine($"{loadProgress.Operation,-15} {loadProgress.ElapsedTime,-15:m\\:ss\\.fffffff} {projectDisplay}");
            }
        }
    }
}
