namespace Microsoft.StandardUI.Controls
{
#if false
    public class HorizontalTableLayoutManager : GridBaseLayoutManager<IHorizontalTable>
    {
        public static HorizontalTableLayoutManager Instance = new HorizontalTableLayoutManager();

        override internal GridInfo CreateGridInfo(IHorizontalTable table, double widthConstraint, double heightConstraint)
        {
            IUICollection<IColumn> tableColumns = table.Columns;
            int columnCount = tableColumns.Count;

            IUICollection<IRowDefinition> tableRowDefinitions = table.RowDefinitions;
            int rowCount = tableRowDefinitions.Count;

            // Compute column definitions (from the columns themselves)
            ColumnDefinitionInfo[] columnDefinitions = new ColumnDefinitionInfo[columnCount];
            for (int i = 0; i < columnCount; i++)
                columnDefinitions[i] = new ColumnDefinitionInfo(tableColumns[i]);

            // Compute row definitions
            RowDefinitionInfo[] rowDefinitions = new RowDefinitionInfo[rowCount];
            for (int i = 0; i < rowCount; i++)
                rowDefinitions[i] = new RowDefinitionInfo(tableRowDefinitions[i]);

            // Compute cells
            var cells = new CellInfo[columnCount * rowCount];
            int cellIndex = 0;
            for (int columnIndex = 0; columnIndex < columnCount; ++columnIndex)
            {
                int rowIndex = 0;
                foreach (IUIElement child in tableColumns[columnIndex].Children)
                {
                    int columnSpan = child.TableColumnSpan().Clamp(1, columnCount - columnIndex);
                    var rowSpan = child.TableRowSpan().Clamp(1, rowCount - rowIndex);

                    // Skip any children that aren't visible
                    if (child.Visible)
                        cells[cellIndex++] = new CellInfo(child, rowIndex, columnIndex, rowSpan, columnSpan);

                    rowIndex += rowSpan;
                }
            }
            if (cellIndex < cells.Length)
                Array.Resize(ref cells, cellIndex);

            return new GridInfo(table, rowDefinitions, columnDefinitions, cells, widthConstraint, heightConstraint);
        }
    }
#endif
}
