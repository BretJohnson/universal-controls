// This file is generated from IGridBase.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class GridBase : BuiltInUIElement, IGridBase
    {
        public static readonly UIProperty ColumnSpacingProperty = new UIProperty(nameof(ColumnSpacing), 0.0);
        public static readonly UIProperty RowSpacingProperty = new UIProperty(nameof(RowSpacing), 0.0);
        
        public double ColumnSpacing
        {
            get => (double) GetNonNullValue(ColumnSpacingProperty);
            set => SetValue(ColumnSpacingProperty, value);
        }
        
        public double RowSpacing
        {
            get => (double) GetNonNullValue(RowSpacingProperty);
            set => SetValue(RowSpacingProperty, value);
        }
    }
}
