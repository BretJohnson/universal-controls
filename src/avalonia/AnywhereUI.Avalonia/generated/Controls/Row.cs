// This file is generated from IRow.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Controls
{
    public class Row : Panel, IRow
    {
        public static readonly Avalonia.StyledProperty<GridLength> HeightProperty = AvaloniaProperty.Register<RowDefinition, GridLength>(nameof(Height), GridLength.Default);
        public static readonly Avalonia.StyledProperty<double> MinHeightProperty = AvaloniaProperty.Register<RowDefinition, double>(nameof(MinHeight), 0.0);
        public static readonly Avalonia.StyledProperty<double> MaxHeightProperty = AvaloniaProperty.Register<RowDefinition, double>(nameof(MaxHeight), double.PositiveInfinity);
        public static readonly Avalonia.StyledProperty<double> ActualHeightProperty = AvaloniaProperty.Register<RowDefinition, double>(nameof(ActualHeight), 0.0);
        
        public GridLength Height
        {
            get => (GridLength) GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }
        
        public double MinHeight
        {
            get => (double) GetValue(MinHeightProperty);
            set => SetValue(MinHeightProperty, value);
        }
        
        public double MaxHeight
        {
            get => (double) GetValue(MaxHeightProperty);
            set => SetValue(MaxHeightProperty, value);
        }
        
        public double ActualHeight => (double) GetValue(ActualHeightProperty);
    }
}
