// This file is generated from IGridBase.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Blazor.Controls
{
    public class GridBase : BuiltInUIElement, IGridBase
    {
        public static readonly UIProperty ColumnSpacingProperty = new UIProperty(nameof(ColumnSpacing), 0.0);
        public static readonly UIProperty RowSpacingProperty = new UIProperty(nameof(RowSpacing), 0.0);
        
        [Parameter]
        public double ColumnSpacing
        {
            get => (double) GetNonNullValue(ColumnSpacingProperty);
            set => SetValue(ColumnSpacingProperty, value);
        }
        
        [Parameter]
        public double RowSpacing
        {
            get => (double) GetNonNullValue(RowSpacingProperty);
            set => SetValue(RowSpacingProperty, value);
        }
    }
}
