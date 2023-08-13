// This file is generated from ITargetPropertyPath.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;

namespace Microsoft.StandardUI.Blazor
{
    public class TargetPropertyPath : StandardUIObject, ITargetPropertyPath
    {
        public static readonly UIProperty PropertyProperty = new UIProperty(nameof(Property), null);
        public static readonly UIProperty TargetProperty = new UIProperty(nameof(Target), null);
        
        [Parameter]
        public IPropertyPath Property
        {
            get => (PropertyPath) GetNonNullValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        
        [Parameter]
        public object Target
        {
            get => (object) GetNonNullValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
    }
}
