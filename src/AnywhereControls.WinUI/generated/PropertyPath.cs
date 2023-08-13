// This file is generated from IPropertyPath.cs. Update the source file to change its contents.

using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI
{
    public class PropertyPath : StandardUIObject, IPropertyPath
    {
        public static readonly DependencyProperty PathProperty = PropertyUtils.Register(nameof(Path), typeof(string), typeof(PropertyPath), "");
        
        public string Path => (string) GetValue(PathProperty);
    }
}
