// This file is generated from IStackBase.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using AnywhereControls.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class StackBase : Panel, IStackBase
    {
        public static readonly UIProperty SpacingProperty = new UIProperty(nameof(Spacing), 0.0);
        
        public double Spacing
        {
            get => (double) GetNonNullValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }
}
