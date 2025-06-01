using System;

namespace UniversalUI.Controls
{
    public class GridLayoutManager : GridBaseLayoutManager<IGrid>
    {
        public static GridLayoutManager Instance = new GridLayoutManager();

        override internal GridInfo CreateGridInfo(IGrid grid, double widthConstraint, double heightConstraint)
        {
            // Compute row definitions
            RowDefinitionInfo[] rowDefinitions;
            IUICollection<IRowDefinition> gridRowDefinitions = grid.RowDefinitions;
            if (gridRowDefinitions.Count == 0)
            {
                // Since no rows are specified, we'll create an implied row 0 
                rowDefinitions = new RowDefinitionInfo[1];
                rowDefinitions[0] = new RowDefinitionInfo(new ImpliedRowDefinition());
            }
            else
            {
                rowDefinitions = new RowDefinitionInfo[gridRowDefinitions.Count];
                for (int i = 0; i < gridRowDefinitions.Count; i++)
                    rowDefinitions[i] = new RowDefinitionInfo(gridRowDefinitions[i]);
            }

            // Compute column definitions
            ColumnDefinitionInfo[] columns;
            IUICollection<IColumnDefinition> gridColumnDefinitions = grid.ColumnDefinitions;
            if (gridColumnDefinitions.Count == 0)
            {
                // Since no columns are specified, we'll create an implied column 0
                columns = new ColumnDefinitionInfo[1];
                columns[0] = new ColumnDefinitionInfo(new ImpliedColumn());
            }
            else
            {
                columns = new ColumnDefinitionInfo[gridColumnDefinitions.Count];
                for (int i = 0; i < gridColumnDefinitions.Count; i++)
                    columns[i] = new ColumnDefinitionInfo(gridColumnDefinitions[i]);
            }

            // Compute cells
            IUICollection<IUIElement> gridChildren = grid.Children;
            var gridChildCount = gridChildren.Count;
            var cells = new CellInfo[gridChildCount];
            int cellIndex = 0;
            for (int n = 0; n < gridChildCount; n++)
            {
                IUIElement child = gridChildren[n];

                // Skip any children that aren't visible
                if (!child.IsVisible)
                    continue;

                var row = child.GridRow().Clamp(0, rowDefinitions.Length - 1);
                int column = child.GridColumn().Clamp(0, columns.Length - 1);

                var rowSpan = child.GridRowSpan().Clamp(1, rowDefinitions.Length - row);
                int columnSpan = child.GridColumnSpan().Clamp(1, columns.Length - column);

                cells[cellIndex++] = new CellInfo(child, row, column, rowSpan, columnSpan);
            }
            if (cellIndex < cells.Length)
                Array.Resize(ref cells, cellIndex);

            return new GridInfo(grid, rowDefinitions, columns, cells, widthConstraint, heightConstraint);
        }

        // If the IGrid doesn't have any rows/columns defined, the manager will use an implied single row or column
        // in their place. 

        internal class ImpliedRowDefinition : IRowDefinition
        {
            public GridLength Height { get => GridLength.Default; set => throw new NotImplementedException(); }

            double IRowDefinition.MinHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            double IRowDefinition.MaxHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            double IRowDefinition.ActualHeight => throw new NotImplementedException();

            void IUIObject.ClearValue(IUIProperty property) => throw new NotImplementedException();
            object? IUIObject.GetValue(IUIProperty property) => throw new NotImplementedException();
            void IUIObject.SetValue(IUIProperty property, object? value) => throw new NotImplementedException();
        }

        internal class ImpliedColumn : IColumnDefinition
        {
            public GridLength Width { get => GridLength.Default; set => throw new NotImplementedException(); }

            double IColumnDefinition.MinWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            double IColumnDefinition.MaxWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            double IColumnDefinition.ActualWidth => throw new NotImplementedException();

            void IUIObject.ClearValue(IUIProperty property) => throw new NotImplementedException();
            object? IUIObject.GetValue(IUIProperty property) => throw new NotImplementedException();
            void IUIObject.SetValue(IUIProperty property, object? value) => throw new NotImplementedException();
        }
    }
}
