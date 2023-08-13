// This file is generated from IGridBase.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Controls
{
    public static class GridBaseExtensions
    {
        public static T ColumnSpacing<T>(this T gridBase, double value) where T : IGridBase
        {
            gridBase.ColumnSpacing = value;
            return gridBase;
        }
        
        public static T RowSpacing<T>(this T gridBase, double value) where T : IGridBase
        {
            gridBase.RowSpacing = value;
            return gridBase;
        }
    }
}
