using System.Text;
using AnywhereUI.SourceGenerator.UIFrameworks;

namespace AnywhereUI.SourceGenerator
{
    public class ClassSource
    {
        public Context Context { get; }

        public Usings Usings { get; }

        public string? GeneratedFrom { get; }

        public Source Attributes { get; }
        public string NamespaceName { get; }
        public bool IsStatic { get; }
        public bool IsPartial { get; }
        public string ClassName { get; }
        public string? FileNameOverride { get; }
        public string? DerivedFrom { get; set; }

        public Source StaticFields { get; }
        public Source NonstaticFields { get; }

        public Source DefaultConstructorBody { get; }
        public Source StaticMethods { get; }
        public Source NonstaticMethods { get; }

        public ClassSource(Context context, string namespaceName, string className, string? fileNameOverride = null, string? generatedFrom = null,
            bool isStatic = false, bool isPartial = false, string? derivedFrom = null)
        {
            Context = context;
            Usings = new Usings(context, namespaceName);

            GeneratedFrom = generatedFrom;

            Attributes = new Source(context, Usings);
            NamespaceName = namespaceName;
            ClassName = className;
            FileNameOverride = fileNameOverride;

            IsStatic = isStatic;
            IsPartial = isPartial;
            DerivedFrom = derivedFrom;

            StaticFields = new Source(context, Usings);
            NonstaticFields = new Source(context, Usings);

            DefaultConstructorBody = new Source(context, Usings);
            StaticMethods = new Source(context, Usings);
            NonstaticMethods = new Source(context, Usings);
        }

        public Source Generate()
        {
            Source fileSource = new Source(Context);

            if (GeneratedFrom != null)
                fileSource.AddLine($"// This file is generated from {GeneratedFrom}. Update the source file to change its contents.");
            else
                fileSource.AddLine($"// This file is generated. Update the source to change its contents.");
            fileSource.AddBlankLine();

            Source usingsDeclarations = Usings.Generate();
            if (!usingsDeclarations.IsEmpty)
            {
                fileSource.AddSource(usingsDeclarations);
                fileSource.AddBlankLine();
            }

            fileSource.AddLines(
                $"namespace {NamespaceName}",
                "{");

            using (fileSource.Indent())
            {
                Source classBody = new Source(Context);
                if (!StaticFields.IsEmpty)
                    classBody.AddSource(StaticFields);
                if (!StaticMethods.IsEmpty)
                {
                    classBody.AddBlankLineIfNonempty();
                    classBody.AddSource(StaticMethods);
                }
                if (!NonstaticFields.IsEmpty)
                {
                    classBody.AddBlankLineIfNonempty();
                    classBody.AddSource(NonstaticFields);
                }
                if (!DefaultConstructorBody.IsEmpty)
                {
                    classBody.AddBlankLineIfNonempty();

                    classBody.AddLines(
                        $"public {ClassName}()",
                        "{");
                    using (classBody.Indent())
                        classBody.AddSource(DefaultConstructorBody);
                    classBody.AddLine(
                        "}");
                }
                if (!NonstaticMethods.IsEmpty)
                {
                    classBody.AddBlankLineIfNonempty();
                    classBody.AddSource(NonstaticMethods);
                }

                if (!Attributes.IsEmpty)
                    fileSource.AddSource(Attributes);

                StringBuilder classLine = new StringBuilder("public");
                if (IsStatic)
                    classLine.Append(" static");
                if (IsPartial)
                    classLine.Append(" partial");
                classLine.Append($" class {ClassName}");
                if (DerivedFrom != null)
                    classLine.Append($" : {DerivedFrom}");
                fileSource.AddLine(classLine.ToString());

                fileSource.AddLine(
                    "{");
                using (fileSource.Indent())
                    fileSource.AddSource(classBody);
                fileSource.AddLine(
                    "}");
            }

            fileSource.AddLine(
                "}");

            return fileSource;
        }

        public void AddToOutput(UIFramework? uiFramework)
        {
            Source fileSource = Generate();
            Context.Output.AddSource(uiFramework, NamespaceName, FileNameOverride ?? ClassName, fileSource);
        }
    }
}
