using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using AnywhereControls.SourceGenerator;
using AnywhereControls.SourceGenerator.UIFrameworks;
using System.Linq;

namespace AnywhereControls.CommandLineSourceGenerator
{
    public static class Generator
    {
        public static async Task Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new UserViewableException($"Usage: AnywhereUI.CommandLineSourceGenerator.exe <path-to-repo-root>");
                }

                string rootDirectory = NormalizePath(args[0]);

                MSBuildLocator.RegisterDefaults();

                using MSBuildWorkspace workspace = MSBuildWorkspace.Create();
                workspace.WorkspaceFailed += (o, e) => Console.WriteLine(e.Diagnostic.Message);

                string anywhereUIProjectPath = Path.Combine(rootDirectory, "src", "AnywhereUI", "AnywhereUI.csproj");
                Console.WriteLine($"Loading project '{anywhereUIProjectPath}'");
                Project anywhereControlsProject = await workspace.OpenProjectAsync(anywhereUIProjectPath, new ConsoleProgressReporter());

                await GenerateClassesForProject(anywhereControlsProject, rootDirectory);

                Project? anywhereUICommonTypesProject = anywhereControlsProject.ProjectReferences
                    .Select(projectRef => workspace.CurrentSolution.GetProject(projectRef.ProjectId))
                    .First(referencedProj => referencedProj?.Name == "AnywhereUI.CommonTypes");

                if (anywhereUICommonTypesProject == null)
                {
                    throw new UserViewableException("Couldn't find referenced AnywhereUI.CommonTypes project");
                }

                await GenerateClassesForProject(anywhereUICommonTypesProject, rootDirectory);
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

        private static async Task GenerateClassesForProject(Project project, string rootDirectory)
        {
            Compilation? compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return;

            var context = new Context(compilation, new DirectoryOutput(rootDirectory));
            var controlLibrary = new ControlLibrary(context, context.Compilation.Assembly);

            Console.WriteLine($"Generating source for these interfaces:");
            foreach (UIObjectType uiObjectType in controlLibrary.UIObjectTypes)
            {
                Console.WriteLine($"{uiObjectType.Name}");
            }

            controlLibrary.GenerateControlClasses(new WpfUIFramework(context));
            controlLibrary.GenerateControlClasses(new AvaloniaUIFramework(context));
            //controlLibrary.GenerateControlClasses(new WinUIUIFramework(context));
            //controlLibrary.GenerateControlClasses(new WinFormsUIFramework(context));
            //controlLibrary.GenerateControlClasses(new MacUIFramework(context));
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
