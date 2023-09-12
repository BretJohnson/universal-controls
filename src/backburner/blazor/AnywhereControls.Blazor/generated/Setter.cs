// This file is generated from ISetter.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.AspNetCore.Components;

namespace AnywhereControls.Blazor
{
    public class Setter : StandardUIObject, ISetter
    {
        public static readonly UIProperty PropertyProperty = new UIProperty(nameof(Property), null);
        public static readonly UIProperty TargetProperty = new UIProperty(nameof(Target), null);
        public static readonly UIProperty ValueProperty = new UIProperty(nameof(Value), null);
        
        [Parameter]
        public IUIProperty? Property
        {
            get => (UIProperty?) GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        
        [Parameter]
        public ITargetPropertyPath Target
        {
            get => (TargetPropertyPath) GetNonNullValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        
        [Parameter]
        public object Value
        {
            get => (object) GetNonNullValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
