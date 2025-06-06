// This file is generated from IPropertyPath.cs. Update the source file to change its contents.

using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace UniversalUI.Maui
{
    public class PropertyPath : UIObject, IPropertyPath
    {
        public static readonly BindableProperty PathProperty = PropertyUtils.Register(nameof(Path), typeof(string), typeof(PropertyPath), "");
        
        public string Path => (string) GetValue(PathProperty);
    }
}
