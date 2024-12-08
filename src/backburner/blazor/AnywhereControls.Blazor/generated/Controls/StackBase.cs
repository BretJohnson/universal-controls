// This file is generated from IStackBase.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using AnywhereUI.Controls;

namespace AnywhereControls.Blazor.Controls
{
    public class StackBase : Panel, IStackBase
    {
        public static readonly UIProperty SpacingProperty = new UIProperty(nameof(Spacing), 0.0);
        
        [Parameter]
        public double Spacing
        {
            get => (double) GetNonNullValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }
}
