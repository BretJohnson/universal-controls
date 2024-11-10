namespace AnywhereControls.Controls
{
#if false
    public class TableLayoutManager : GridBaseLayoutManager<ITable>
    {
        public static TableLayoutManager Instance = new TableLayoutManager();

        override internal GridInfo CreateGridInfo(ITable table, double widthConstraint, double heightConstraint)
        {
            IUICollection<IRow> tableRows = table.Rows;
            int rowCount = tableRows.Count;

            IUICollection<IColumnDefinition> tableColumnDefinitions = table.ColumnDefinitions;
            int columnCount = tableColumnDefinitions.Count;

            // Compute row definitions (from the rows themselves)
            RowDefinitionInfo[] rowDefinitions = new RowDefinitionInfo[rowCount];
            for (int i = 0; i < rowCount; i++)
                rowDefinitions[i] = new RowDefinitionInfo(tableRows[i]);

            // Compute column definitions
            ColumnDefinitionInfo[] columnDefinitions = new ColumnDefinitionInfo[columnCount];
            for (int i = 0; i < columnCount; i++)
                columnDefinitions[i] = new ColumnDefinitionInfo(tableColumnDefinitions[i]);

            // Compute cells
            var cells = new CellInfo[rowCount * columnCount];
            int cellIndex = 0;
            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                int columnIndex = 0;
                foreach (IUIElement child in tableRows[rowIndex].Children)
                {
                    var rowSpan = child.TableRowSpan().Clamp(1, rowCount - rowIndex);
                    int columnSpan = child.TableColumnSpan().Clamp(1, columnCount - columnIndex);

                    // Skip any children that aren't visible
                    if (child.Visible)
                        cells[cellIndex++] = new CellInfo(child, rowIndex, columnIndex, rowSpan, columnSpan);

                    columnIndex += columnSpan;
                }
            }
            if (cellIndex < cells.Length)
                Array.Resize(ref cells, cellIndex);

            return new GridInfo(table, rowDefinitions, columnDefinitions, cells, widthConstraint, heightConstraint);
        }
    }
#endif
}
