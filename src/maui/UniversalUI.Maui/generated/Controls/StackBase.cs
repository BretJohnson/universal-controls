// This file is generated from IStackBase.cs. Update the source file to change its contents.

using UniversalUI.Controls;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace UniversalUI.Maui.Controls
{
    public class StackBase : Panel, IStackBase
    {
        public static readonly BindableProperty SpacingProperty = PropertyUtils.Register(nameof(Spacing), typeof(double), typeof(StackBase), 0.0);
        
        public double Spacing
        {
            get => (double) GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }
}
