// This file is generated from IGrid.cs. Update the source file to change its contents.

using System;

namespace UniversalUI.Controls
{
    public static class GridExtensions
    {
        private static readonly Lazy<IGridAttached> s_GridAttached = new Lazy<IGridAttached>(() => HostEnvironment.Factory.GridAttachedInstance);
        public static IGridAttached GridAttachedInstance => s_GridAttached.Value;
        
        public static T ColumnDefinitions<T>(this T grid, params IColumnDefinition[] value) where T : IGrid
        {
            grid.ColumnDefinitions.Set(value);
            return grid;
        }
        
        public static T RowDefinitions<T>(this T grid, params IRowDefinition[] value) where T : IGrid
        {
            grid.RowDefinitions.Set(value);
            return grid;
        }
        
        public static T ColumnSpacing<T>(this T grid, double value) where T : IGrid
        {
            grid.ColumnSpacing = value;
            return grid;
        }
        
        public static T RowSpacing<T>(this T grid, double value) where T : IGrid
        {
            grid.RowSpacing = value;
            return grid;
        }
        
        // Attached properties
        
        public static int GridRow<T>(this T uiElement) where T : IUIElement => GridAttachedInstance.GetRow(uiElement);
        public static T GridRow<T>(this T uiElement, int value) where T : IUIElement
        {
            GridAttachedInstance.SetRow(uiElement, value);
            return uiElement;
        }
        
        public static int GridColumn<T>(this T uiElement) where T : IUIElement => GridAttachedInstance.GetColumn(uiElement);
        public static T GridColumn<T>(this T uiElement, int value) where T : IUIElement
        {
            GridAttachedInstance.SetColumn(uiElement, value);
            return uiElement;
        }
        
        public static int GridRowSpan<T>(this T uiElement) where T : IUIElement => GridAttachedInstance.GetRowSpan(uiElement);
        public static T GridRowSpan<T>(this T uiElement, int value) where T : IUIElement
        {
            GridAttachedInstance.SetRowSpan(uiElement, value);
            return uiElement;
        }
        
        public static int GridColumnSpan<T>(this T uiElement) where T : IUIElement => GridAttachedInstance.GetColumnSpan(uiElement);
        public static T GridColumnSpan<T>(this T uiElement, int value) where T : IUIElement
        {
            GridAttachedInstance.SetColumnSpan(uiElement, value);
            return uiElement;
        }
    }
}
