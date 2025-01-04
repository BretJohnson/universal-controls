// This file is generated from IStackBase.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Controls
{
    public class StackBase : Panel, IStackBase
    {
        public static readonly Avalonia.StyledProperty<double> SpacingProperty = AvaloniaProperty.Register<StackBase, double>(nameof(Spacing), 0.0);
        
        public double Spacing
        {
            get => (double) GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }
}
