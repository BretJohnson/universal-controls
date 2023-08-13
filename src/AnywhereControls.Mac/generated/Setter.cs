// This file is generated from ISetter.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;

namespace Microsoft.StandardUI.Mac
{
    public class Setter : StandardUIObject, ISetter
    {
        public static readonly UIProperty PropertyProperty = new UIProperty(nameof(Property), null);
        public static readonly UIProperty TargetProperty = new UIProperty(nameof(Target), null);
        public static readonly UIProperty ValueProperty = new UIProperty(nameof(Value), null);
        
        public IUIProperty? Property
        {
            get => (UIProperty?) GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        
        public ITargetPropertyPath Target
        {
            get => (TargetPropertyPath) GetNonNullValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        
        public object Value
        {
            get => (object) GetNonNullValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
