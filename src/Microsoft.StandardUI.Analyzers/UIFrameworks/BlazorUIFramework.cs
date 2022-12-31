namespace Microsoft.StandardUI.SourceGenerator.UIFrameworks
{
    public class BlazorUIFramework : NonXamlUIFramework
    {
        public BlazorUIFramework(Context context) : base(context)
        {
        }

        public override string Name => "Blazor";
        public override string FrameworkTypeForUIElementAttachedTarget => "Microsoft.AspNetCore.Components.ComponentBase";
        public override string NativeUIElementType => "";   // TODO: Supply right value here
        protected override string FontFamilyDefaultValue => "\"\""; // TODO: Supply right value here

        public override void GeneratePropertyAttribute(Property property, Source source)
        {
            if (! property.IsReadOnly)
            {
                source.Usings.AddNamespace("Microsoft.AspNetCore.Components");
                source.AddLine("[Parameter]");
            }
        }

        public override void GeneratePanelMethods(Source methods)
        {
            methods.Usings.AddNamespace("Microsoft.AspNetCore.Components");
            methods.Usings.AddNamespace("Microsoft.AspNetCore.Components.Rendering");
            methods.Usings.AddNamespace("System.Collections");

            methods.AddBlankLineIfNonempty();

            methods.AddLines(
                "public override int VisualChildrenCount => _children.Count;");
            methods.AddBlankLine();
            methods.AddLine(
                "public override IUIElement GetVisualChild(int index) => _children[index];");

            methods.AddBlankLine();
            methods.AddLines(
                "[Parameter]",
                "public RenderFragment? ChildContent { get; set; }");

            methods.AddLines(
                "protected override void BuildRenderTree(RenderTreeBuilder builder)",
                "{",
                "    base.BuildRenderTree(builder);",
                "",
                "    // Use a CascadingValue to tell the children about their parent, so they add",
                "    // themselves to the Children list",
                "    RenderFragment ? childContent = ChildContent;",
                "    if (childContent != null)",
                "    {",
                "        builder.OpenComponent<CascadingValue<IList?>>(11);",
                "        builder.AddAttribute(12, \"Value\", Children);",
                "        builder.AddAttribute(13, \"Name\", \"ParentingInfo\");",
                "",
                "        builder.AddAttribute(14, \"ChildContent\", (RenderFragment)((builder2) => {",
                "            builder2.AddContent(15, childContent); ",
                "        }));",
                "        builder.CloseComponent();",
                "    }",
                "}");
        }
    }
}