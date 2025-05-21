// This file is generated from ITargetPropertyPath.cs. Update the source file to change its contents.

using UniversalUI;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia
{
    public class TargetPropertyPath : UIObject, ITargetPropertyPath
    {
        public static readonly Avalonia.StyledProperty<PropertyPath> PropertyProperty = AvaloniaProperty.Register<TargetPropertyPath, PropertyPath>(nameof(Property), null);
        public static readonly Avalonia.StyledProperty<object> TargetProperty = AvaloniaProperty.Register<TargetPropertyPath, object>(nameof(Target), null);
        
        public PropertyPath Property
        {
            get => (PropertyPath) GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        IPropertyPath ITargetPropertyPath.Property
        {
            get => Property;
            set => Property = (PropertyPath) value;
        }
        
        public object Target
        {
            get => (object) GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
    }
}
