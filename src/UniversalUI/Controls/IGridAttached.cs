using System.ComponentModel;

namespace UniversalUI.Controls
{
    [UIModelObject]
    public interface IGridAttached
    {
        /// <summary>
        /// Zero based index of the grid row that the element should appear within. Negative values are not permitted.
        /// </summary>
        [DefaultValue(0)]
        int GetRow(IUIElement element);
        void SetRow(IUIElement element, int row);

        /// <summary>
        /// Zero based index of the grid colmn that the element should appear within. Negative values are not permitted.
        /// </summary>
        [DefaultValue(0)]
        int GetColumn(IUIElement element);
        void SetColumn(IUIElement element, int columnb);

        /// <summary>
        /// Total number of rows that the element spans within the parent grid. Zero or negative integer values are not permitted.
        /// Values that are greater than the total number of rows are treated as if they specified the total number and will span
        /// all rows.
        /// </summary>
        [DefaultValue(1)]
        int GetRowSpan(IUIElement element);
        void SetRowSpan(IUIElement element, int rowSpan);

        /// <summary>
        /// Total number of columns that the element spans within the parent grid. Zero or negative integer values are not permitted.
        /// Values that are greater than the total number of columns are treated as if they specified the total number and will span
        /// all columns.
        /// </summary>
        [DefaultValue(1)]
        int GetColumnSpan(IUIElement element);
        void SetColumnSpan(IUIElement element, int columnSpan);
    }
}
