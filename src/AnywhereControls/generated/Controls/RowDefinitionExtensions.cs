// This file is generated from IRowDefinition.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Controls
{
    public static class RowDefinitionExtensions
    {
        public static T Height<T>(this T rowDefinition, GridLength value) where T : IRowDefinition
        {
            rowDefinition.Height = value;
            return rowDefinition;
        }
        
        public static T MinHeight<T>(this T rowDefinition, double value) where T : IRowDefinition
        {
            rowDefinition.MinHeight = value;
            return rowDefinition;
        }
        
        public static T MaxHeight<T>(this T rowDefinition, double value) where T : IRowDefinition
        {
            rowDefinition.MaxHeight = value;
            return rowDefinition;
        }
    }
}
