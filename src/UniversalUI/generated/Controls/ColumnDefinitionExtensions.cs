// This file is generated from IColumnDefinition.cs. Update the source file to change its contents.

namespace UniversalUI.Controls
{
    public static class ColumnDefinitionExtensions
    {
        public static T Width<T>(this T columnDefinition, GridLength value) where T : IColumnDefinition
        {
            columnDefinition.Width = value;
            return columnDefinition;
        }
        
        public static T MinWidth<T>(this T columnDefinition, double value) where T : IColumnDefinition
        {
            columnDefinition.MinWidth = value;
            return columnDefinition;
        }
        
        public static T MaxWidth<T>(this T columnDefinition, double value) where T : IColumnDefinition
        {
            columnDefinition.MaxWidth = value;
            return columnDefinition;
        }
    }
}
