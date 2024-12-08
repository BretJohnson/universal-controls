// This file is generated from IPropertyPath.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;

namespace AnywhereControls.Blazor
{
    public class PropertyPath : UIObject, IPropertyPath
    {
        public static readonly UIProperty PathProperty = new UIProperty(nameof(Path), "", readOnly:true);
        
        public string Path => (string) GetNonNullValue(PathProperty);
    }
}
