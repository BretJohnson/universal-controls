// This file is generated from IPropertyPath.cs. Update the source file to change its contents.

using AnywhereUI;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia
{
    public class PropertyPath : UIObject, IPropertyPath
    {
        public static readonly Avalonia.StyledProperty<string> PathProperty = AvaloniaProperty.Register<PropertyPath, string>(nameof(Path), "");
        
        public string Path => (string) GetValue(PathProperty);
    }
}
