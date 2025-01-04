// This file is generated from IColumnDefinition.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Controls
{
    public class ColumnDefinition : UIObject, IColumnDefinition
    {
        public static readonly Avalonia.StyledProperty<GridLength> WidthProperty = AvaloniaProperty.Register<ColumnDefinition, GridLength>(nameof(Width), GridLength.Default);
        public static readonly Avalonia.StyledProperty<double> MinWidthProperty = AvaloniaProperty.Register<ColumnDefinition, double>(nameof(MinWidth), 0.0);
        public static readonly Avalonia.StyledProperty<double> MaxWidthProperty = AvaloniaProperty.Register<ColumnDefinition, double>(nameof(MaxWidth), double.PositiveInfinity);
        public static readonly Avalonia.StyledProperty<double> ActualWidthProperty = AvaloniaProperty.Register<ColumnDefinition, double>(nameof(ActualWidth), 0.0);
        
        public GridLength Width
        {
            get => (GridLength) GetValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }
        
        public double MinWidth
        {
            get => (double) GetValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }
        
        public double MaxWidth
        {
            get => (double) GetValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }
        
        public double ActualWidth => (double) GetValue(ActualWidthProperty);
    }
}
