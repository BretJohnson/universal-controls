// This file is generated from IGridBase.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class GridBase : BuiltInUIElement, IGridBase
    {
        public static readonly Avalonia.StyledProperty<double> ColumnSpacingProperty = AvaloniaProperty.Register<GridBase, double>(nameof(ColumnSpacing), 0.0);
        public static readonly Avalonia.StyledProperty<double> RowSpacingProperty = AvaloniaProperty.Register<GridBase, double>(nameof(RowSpacing), 0.0);
        
        public double ColumnSpacing
        {
            get => (double) GetValue(ColumnSpacingProperty);
            set => SetValue(ColumnSpacingProperty, value);
        }
        
        public double RowSpacing
        {
            get => (double) GetValue(RowSpacingProperty);
            set => SetValue(RowSpacingProperty, value);
        }
    }
}
