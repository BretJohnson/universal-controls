// This file is generated from ISetter.cs. Update the source file to change its contents.

using AnywhereControls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia
{
    public class Setter : UIObject, ISetter
    {
        public static readonly Avalonia.StyledProperty<UIProperty?> PropertyProperty = AvaloniaProperty.Register<Setter, UIProperty?>(nameof(Property), null);
        public static readonly Avalonia.StyledProperty<TargetPropertyPath> TargetProperty = AvaloniaProperty.Register<Setter, TargetPropertyPath>(nameof(Target), null);
        public static readonly Avalonia.StyledProperty<object> ValueProperty = AvaloniaProperty.Register<Setter, object>(nameof(Value), null);
        
        public UIProperty? Property
        {
            get => (UIProperty?) GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        IUIProperty? ISetter.Property
        {
            get => Property;
            set => Property = (UIProperty?) value;
        }
        
        public TargetPropertyPath Target
        {
            get => (TargetPropertyPath) GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        ITargetPropertyPath ISetter.Target
        {
            get => Target;
            set => Target = (TargetPropertyPath) value;
        }
        
        public object Value
        {
            get => (object) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
