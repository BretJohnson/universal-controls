namespace AnywhereControls.SourceGenerator.UIFrameworks
{
    public class MauiUIFramework : XamlUIFramework
    {
        public MauiUIFramework(Context context) : base(context)
        {
        }

        public override string Name => "Maui";
        public override TypeName DependencyPropertyType => new("Microsoft.Maui.Controls", "BindableProperty");
        public override TypeName ContentPropertyAttribute => new("Microsoft.Maui.Controls", "ContentPropertyAttribute");

        public override string FrameworkTypeForUIElementAttachedTarget => "Microsoft.Maui.Controls.View";
        public override string ToFrameworkTypeForUIElementAttachedTarget => "ToView";

        public override string NativeUIElementType => "Microsoft.Maui.Controls.View";
        public override string WrapperSuffix => "Maui";
        protected override string FontFamilyDefaultValue => "\"\""; // TODO: Supply right value here

        public override void AddTypeAliasUsingIfNeeded(Usings usings, string destinationTypeName)
        {
            // These types are also defined in Maui, so add aliases to prefer the Anywhere Controls type
            if (destinationTypeName == "Brush" || destinationTypeName == "Brush?")
                usings.AddTypeAlias("Brush = AnywhereControls.Maui.Media.Brush");
            else if (destinationTypeName == "Color")
                usings.AddTypeAlias("Color = AnywhereControls.Color");
            else if (destinationTypeName == "Colors")
                usings.AddTypeAlias("Colors = AnywhereControls.Colors");
            else if (destinationTypeName == "SweepDirection")
                usings.AddTypeAlias("SweepDirection = AnywhereControls.Media.SweepDirection");
        }

        public override void GenerateStandardPanelLayoutMethods(string layoutManagerTypeName, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine($"protected override Microsoft.Maui.Graphics.Size MeasureOverride(double widthConstraint, double heightConstraint) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.MeasureOverride(this, widthConstraint, heightConstraint).ToMauiSize();");
            }

            methods.AddBlankLine();
            methods.AddLine($"protected override Microsoft.Maui.Graphics.Size ArrangeOverride(Microsoft.Maui.Graphics.Rect bounds) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.ArrangeOverride(this, bounds.Size.ToAnywhereControlsSize()).ToMauiSize();");
            }
        }
    }
}
