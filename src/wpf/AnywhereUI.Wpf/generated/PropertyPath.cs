// This file is generated from IPropertyPath.cs. Update the source file to change its contents.

using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf
{
    public class PropertyPath : UIObject, IPropertyPath
    {
        public static readonly DependencyProperty PathProperty = PropertyUtils.Register(nameof(Path), typeof(string), typeof(PropertyPath), "");
        
        public string Path => (string) GetValue(PathProperty);
    }
}
