using System;
using System.Collections.Generic;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Controls;

namespace StandardUI.Controls
{
    public abstract class GridBaseLayoutManager<TGridBase> : LayoutManager<TGridBase> where TGridBase : IGrid
    {
        abstract internal GridInfo CreateGridInfo(TGridBase grid, double widthConstraint, double heightConstraint);

        public override Size MeasureOverride(TGridBase grid, double widthConstraint, double heightConstraint)
        {
            GridInfo gridInfo = CreateGridInfo(grid, widthConstraint, heightConstraint);

            double measuredWidth = gridInfo.MeasuredGridWidth();
            double measuredHeight = gridInfo.MeasuredGridHeight();

            return new Size(measuredWidth, measuredHeight);
        }

        public override Size ArrangeOverride(TGridBase gridBase, Size finalSize)
        {
            GridInfo gridInfo = CreateGridInfo(gridBase, finalSize.Width, finalSize.Height);

            CellInfo[] cells = gridInfo.Cells;
            for (var i = 0; i < cells.Length; i++)
            {
                CellInfo cell = cells[i];

                // TODO: Determine if need to support non zero position for top/left
                //var cell = gridStructure.GetCellBoundsFor(child, bounds.Left, bounds.Top);
                Rect cellBouds = gridInfo.GetCellBoundsFor(cell, 0, 0);

                cell.Child.Arrange(cellBouds);
            }

            var actual = new Size(gridInfo.MeasuredGridWidth(), gridInfo.MeasuredGridHeight());
            return AdjustForStretchToFill(gridBase, actual.Width, actual.Height, finalSize);
        }

        internal class GridInfo
        {
            public CellInfo[] Cells { get; }

            private readonly double _gridWidthConstraint;
            private readonly double _gridHeightConstraint;
            private readonly double _explicitGridHeight;
            private readonly double _explicitGridWidth;
            private readonly double _gridMaxHeight;
            private readonly double _gridMinHeight;
            private readonly double _gridMaxWidth;
            private readonly double _gridMinWidth;

            private RowDefinitionInfo[] _rows { get; }
            private ColumnDefinitionInfo[] _columns { get; }

            private readonly Thickness _padding;
            private readonly double _rowSpacing;
            private readonly double _columnSpacing;

            private readonly Dictionary<SpanKey, Span> _spans = new();

            public GridInfo(IGrid gridBase, RowDefinitionInfo[] rows, ColumnDefinitionInfo[] columns, CellInfo[] cells, double widthConstraint, double heightConstraint)
            {
                _gridWidthConstraint = widthConstraint;
                _gridHeightConstraint = heightConstraint;

                _explicitGridHeight = gridBase.Height;
                _explicitGridWidth = gridBase.Width;
                _gridMaxHeight = gridBase.MaxHeight;
                _gridMinHeight = gridBase.MinHeight;
                _gridMaxWidth = gridBase.MaxWidth;
                _gridMinWidth = gridBase.MinWidth;

                _columnSpacing = gridBase.ColumnSpacing;
                _rowSpacing = gridBase.RowSpacing;

                _rows = rows;
                _columns = columns;

                Cells = cells;

                SetCellsGridLengthTypes();
                MeasureCells();
            }

            public Rect GetCellBoundsFor(CellInfo cell, double xOffset, double yOffset)
            {
                var firstColumn = cell.Column.Clamp(0, _columns.Length - 1);
                var columnSpan = cell.ColumnSpan.Clamp(1, _columns.Length - firstColumn);
                var lastColumn = firstColumn + columnSpan;

                var firstRow = cell.Row.Clamp(0, _rows.Length - 1);
                var rowSpan = cell.RowSpan.Clamp(1, _rows.Length - firstRow);
                var lastRow = firstRow + rowSpan;

                var top = TopEdgeOfRow(firstRow);
                var left = LeftEdgeOfColumn(firstColumn);

                double width = 0;
                double height = 0;

                for (var i = firstColumn; i < lastColumn; i++)
                    width += _columns[i].Size;

                for (var i = firstRow; i < lastRow; i++)
                    height += _rows[i].Size;

                // Account for any space between spanned rows/columns
                width += (columnSpan - 1) * _columnSpacing;
                height += (rowSpan - 1) * _rowSpacing;

                return new Rect(left + xOffset, top + yOffset, width, height);
            }

            /// <summary>
            /// Set the row and column GridLengthType for each cell, taking into account the GridLengthType
            /// of spanned rows/columns.
            /// </summary>
            private void SetCellsGridLengthTypes()
            {
                // If the width/height constraints are infinity, then Star rows/columns won't really make any sense.
                // When that happens, we need to tag the cells so they can be measured as Auto cells instead.
                bool isGridWidthConstraintInfinite = double.IsInfinity(_gridWidthConstraint);
                bool isGridHeightConstraintInfinite = double.IsInfinity(_gridHeightConstraint);

                CellInfo[] cells = Cells;
                for (var n = 0; n < cells.Length; n++)
                {
                    CellInfo cell = cells[n];

                    var rowGridLengthType = GridLengthType.None;
                    int row = cell.Row;
                    int rowSpan = cell.RowSpan;
                    for (int spannedRow = row; spannedRow < row + rowSpan; spannedRow++)
                        rowGridLengthType |= ToGridLengthType(_rows[spannedRow].RowDefinition.Height.GridUnitType);

                    GridLengthType columnGridLengthType = GridLengthType.None;
                    int column = cell.Column;
                    int columnSpan = cell.ColumnSpan;
                    for (int spannedColumn = column; spannedColumn < column + columnSpan; spannedColumn++)
                        columnGridLengthType |= ToGridLengthType(_columns[spannedColumn].ColumnDefinition.Width.GridUnitType);

                    // Check for infinite constraints and Stars, so we can mark them for measurement as if they were Auto
                    var measureStarAsAuto = (isGridHeightConstraintInfinite && IsStar(rowGridLengthType))
                        || (isGridWidthConstraintInfinite && IsStar(columnGridLengthType));

                    cell.SetGridLengthTypes(rowGridLengthType, columnGridLengthType, measureStarAsAuto);
                }
            }

            public double GridHeight() => SumDefinitions(_rows, _rowSpacing) + _padding.VerticalThickness;

            public double GridWidth() => SumDefinitions(_columns, _columnSpacing) + _padding.HorizontalThickness;

            public double MeasuredGridHeight()
            {
                var height = _explicitGridHeight > -1 ? _explicitGridHeight : GridHeight();

                if (_gridMaxHeight >= 0 && height > _gridMaxHeight)
                    height = _gridMaxHeight;

                if (_gridMinHeight >= 0 && height < _gridMinHeight)
                    height = _gridMinHeight;

                return height;
            }

            public double MeasuredGridWidth()
            {
                var width = _explicitGridWidth > -1 ? _explicitGridWidth : GridWidth();

                if (_gridMaxWidth >= 0 && width > _gridMaxWidth)
                {
                    width = _gridMaxWidth;
                }

                if (_gridMinWidth >= 0 && width < _gridMinWidth)
                {
                    width = _gridMinWidth;
                }

                return width;
            }

            private double SumDefinitions(RowColumnDefinitionInfo[] definitions, double spacing)
            {
                double sum = 0;

                for (var n = 0; n < definitions.Length; n++)
                {
                    var current = definitions[n].Size;

                    if (current <= 0)
                    {
                        continue;
                    }

                    sum += current;

                    if (n > 0)
                    {
                        sum += spacing;
                    }
                }

                return sum;
            }

            private void MeasureCells()
            {
                CellInfo[] cells = Cells;
                for (var n = 0; n < cells.Length; n++)
                {
                    CellInfo cell = cells[n];

                    if (cell.ColumnGridLengthType == GridLengthType.Pixel
                        && cell.RowGridLengthType == GridLengthType.Pixel)
                    {
                        continue;
                    }

                    double availableWidth = AvailableWidth(cell);
                    double availableHeight = AvailableHeight(cell);

                    IUIElement child = cell.Child;

                    if (cell.IsColumnSpanAuto || cell.IsRowSpanAuto || cell.MeasureStarAsAuto)
                    {
                        child.Measure(availableWidth, availableHeight);
                        var measure = child.DesiredSize;

                        if (cell.IsColumnSpanAuto)
                        {
                            if (cell.ColumnSpan == 1)
                            {
                                _columns[cell.Column].Update(measure.Width);
                            }
                            else
                            {
                                var span = new Span(cell.Column, cell.ColumnSpan, true, measure.Width);
                                TrackSpan(span);
                            }
                        }

                        if (cell.IsRowSpanAuto)
                        {
                            if (cell.RowSpan == 1)
                            {
                                _rows[cell.Row].Update(measure.Height);
                            }
                            else
                            {
                                var span = new Span(cell.Row, cell.RowSpan, false, measure.Height);
                                TrackSpan(span);
                            }
                        }
                    }
                }

                ResolveSpans();

                ResolveStarColumns();
                ResolveStarRows();

                EnsureFinalMeasure();
            }

            private void TrackSpan(Span span)
            {
                if (_spans.TryGetValue(span.Key, out var otherSpan))
                {
                    // This span may replace an equivalent but smaller span
                    if (span.Requested > otherSpan.Requested)
                    {
                        _spans[span.Key] = span;
                    }
                }
                else
                {
                    _spans[span.Key] = span;
                }
            }

            private void ResolveSpans()
            {
                foreach (var span in _spans.Values)
                {
                    if (span.IsColumn)
                    {
                        ResolveSpan(_columns, span.Start, span.Length, _columnSpacing, span.Requested);
                    }
                    else
                    {
                        ResolveSpan(_rows, span.Start, span.Length, _rowSpacing, span.Requested);
                    }
                }
            }

            private void ResolveSpan(RowColumnDefinitionInfo[] definitions, int start, int length, double spacing, double requestedSize)
            {
                double currentSize = 0;
                var end = start + length;

                // Determine how large the spanned area currently is
                for (var n = start; n < end; n++)
                {
                    currentSize += definitions[n].Size;

                    if (n > start)
                    {
                        currentSize += spacing;
                    }
                }

                if (requestedSize <= currentSize)
                {
                    // If our request fits in the current size, we're good
                    return;
                }

                // Figure out how much more space we need in this span
                var required = requestedSize - currentSize;

                // And how many parts of the span to distribute that space over
                var autoCount = 0;
                for (var n = start; n < end; n++)
                {
                    if (definitions[n].IsAuto)
                    {
                        autoCount += 1;
                    }
                }

                var distribution = required / autoCount;

                // And distribute that over the rows/columns in the span
                for (var n = start; n < end; n++)
                {
                    if (definitions[n].IsAuto)
                    {
                        definitions[n].Size += distribution;
                    }
                }
            }

            private double LeftEdgeOfColumn(int column)
            {
                var left = _padding.Left;

                for (var n = 0; n < column; n++)
                {
                    left += _columns[n].Size;
                    left += _columnSpacing;
                }

                return left;
            }

            private double TopEdgeOfRow(int row)
            {
                var top = _padding.Top;

                for (var n = 0; n < row; n++)
                {
                    top += _rows[n].Size;
                    top += _rowSpacing;
                }

                return top;
            }

            private void ResolveStars(RowColumnDefinitionInfo[] defs, double availableSpace, Func<CellInfo, bool> cellCheck, Func<Size, double> dimension)
            {
                // Count up the total weight of star columns (e.g., "*, 3*, *" == 5)

                var starCount = 0.0;

                foreach (var definition in defs)
                {
                    if (definition.IsStar)
                    {
                        starCount += definition.GridLength.Value;
                    }
                }

                if (starCount == 0)
                {
                    return;
                }

                double starSize = 0;

                if (double.IsInfinity(availableSpace))
                {
                    // If the available space we're measuring is infinite, then the 'star' doesn't really mean anything
                    // (each one would be infinite). So instead we'll use the size of the actual view in the star row/column.
                    // This means that an empty star row/column goes to zero if the available space is infinite. 

                    foreach (var cell in Cells)
                    {
                        if (cellCheck(cell)) // Check whether this cell should count toward the type of star value were measuring
                        {
                            // Update the star width if the view in this cell is bigger
                            starSize = Math.Max(starSize, dimension(cell.Child.DesiredSize));
                        }
                    }
                }
                else
                {
                    // If we have a finite space, we can divvy it up among the full star weight
                    starSize = availableSpace / starCount;
                }

                foreach (var definition in defs)
                {
                    if (definition.IsStar)
                    {
                        // Give the star row/column the appropriate portion of the space based on its weight
                        definition.Size = starSize * definition.GridLength.Value;
                    }
                }
            }

            private void ResolveStarColumns()
            {
                var availableSpace = _gridWidthConstraint - GridWidth();
                static bool cellCheck(CellInfo cell) => cell.IsColumnSpanStar;
                static double getDimension(Size size) => size.Width;

                ResolveStars(_columns, availableSpace, cellCheck, getDimension);
            }

            private void ResolveStarRows()
            {
                var availableSpace = _gridHeightConstraint - GridHeight();
                static bool cellCheck(CellInfo cell) => cell.IsRowSpanStar;
                static double getDimension(Size size) => size.Height;

                ResolveStars(_rows, availableSpace, cellCheck, getDimension);
            }

            private void EnsureFinalMeasure()
            {
                CellInfo[] cells = Cells;
                for (int i = 0; i < cells.Length; ++i)
                {
                    CellInfo cell = cells[i];

                    double width = 0;
                    double height = 0;

                    for (var n = cell.Row; n < cell.Row + cell.RowSpan; n++)
                    {
                        height += _rows[n].Size;
                    }

                    for (var n = cell.Column; n < cell.Column + cell.ColumnSpan; n++)
                    {
                        width += _columns[n].Size;
                    }

                    cell.Child.Measure(width, height);
                }
            }

            private double AvailableWidth(CellInfo cell)
            {
                var alreadyUsed = GridWidth();
                var available = _gridWidthConstraint - alreadyUsed;

                // Because our cell may overlap columns that are already measured (and counted in GridWidth()),
                // we'll need to add the size of those columns back into our available space
                double cellColumnsWidth = 0;

                for (var c = cell.Column; c < cell.Column + cell.ColumnSpan; c++)
                {
                    cellColumnsWidth += _columns[c].Size;
                }

                cellColumnsWidth += (cell.ColumnSpan - 1) * _columnSpacing;

                return available + cellColumnsWidth;
            }

            private double AvailableHeight(CellInfo cell)
            {
                var alreadyUsed = GridHeight();
                var available = _gridHeightConstraint - alreadyUsed;

                // Because our cell may overlap rows that are already measured (and counted in GridHeight()),
                // we'll need to add the size of those rows back into our available space
                double cellRowsHeight = 0;

                for (var c = cell.Row; c < cell.Row + cell.RowSpan; c++)
                {
                    cellRowsHeight += _rows[c].Size;
                }

                cellRowsHeight += (cell.RowSpan - 1) * _rowSpacing;

                return available + cellRowsHeight;
            }
        }

        // Dictionary key for tracking a Span
        private struct SpanKey
        {
            public int Start { get; }
            public int Length { get; }
            public bool IsColumn { get; }

            public SpanKey(int start, int length, bool isColumn)
            {
                Start = start;
                Length = length;
                IsColumn = isColumn;
            }

            public override bool Equals(object? obj)
            {
                return obj is SpanKey key &&
                       Start == key.Start &&
                       Length == key.Length &&
                       IsColumn == key.IsColumn;
            }

            public override int GetHashCode()
            {
                var hashCode = -1566178749;
                hashCode = hashCode * -1521134295 + Start.GetHashCode();
                hashCode = hashCode * -1521134295 + Length.GetHashCode();
                hashCode = hashCode * -1521134295 + IsColumn.GetHashCode();
                return hashCode;
            }
        }

        private class Span
        {
            public int Start { get; }
            public int Length { get; }
            public bool IsColumn { get; }
            public double Requested { get; }

            public SpanKey Key { get; }

            public Span(int start, int length, bool isColumn, double requestedLength)
            {
                Start = start;
                Length = length;
                IsColumn = isColumn;
                Requested = requestedLength;

                Key = new SpanKey(Start, Length, IsColumn);
            }
        }

        internal class CellInfo
        {
            public IUIElement Child { get; }
            public int Row { get; }
            public int Column { get; }
            public int RowSpan { get; }
            public int ColumnSpan { get; }

            /// <summary>
            /// A combination of all the measurement types in the columns this cell spans
            /// </summary>
            public GridLengthType ColumnGridLengthType { get; private set; }

            /// <summary>
            /// A combination of all the measurement types in the rows this cell spans
            /// </summary>
            public GridLengthType RowGridLengthType { get; private set; }

            /// <summary>
            /// Marks the cell as requiring initial measurement even though the measurement type is Star
            /// Star measurements don't make sense when the axis constraint is infinity; when that happens, we treat them 
            /// Auto instead. We need to tag that situation in the Cell so the Auto measurement can happen; otherwise, we 
            /// can end up with un-measured controls when resolving the Star cells.
            /// </summary>
            public bool MeasureStarAsAuto { get; private set; }

            internal CellInfo(IUIElement child, int row, int column, int rowSpan, int columnSpan)
            {
                Child = child;
                Row = row;
                Column = column;
                RowSpan = rowSpan;
                ColumnSpan = columnSpan;
            }

            internal void SetGridLengthTypes(GridLengthType rowGridLengthType, GridLengthType columnGridLengthType, bool measureStarAsAuto)
            {
                RowGridLengthType = rowGridLengthType;
                ColumnGridLengthType = columnGridLengthType;
                MeasureStarAsAuto = measureStarAsAuto;
            }

            public bool IsColumnSpanAuto => HasFlag(ColumnGridLengthType, GridLengthType.Auto);
            public bool IsRowSpanAuto => HasFlag(RowGridLengthType, GridLengthType.Auto);
            public bool IsColumnSpanStar => HasFlag(ColumnGridLengthType, GridLengthType.Star);
            public bool IsRowSpanStar => HasFlag(RowGridLengthType, GridLengthType.Star);

            private bool HasFlag(GridLengthType a, GridLengthType b)
            {
                // Avoiding Enum.HasFlag here for performance reasons; we don't need the type check
                return (a & b) == b;
            }
        }

        [Flags]

        internal enum GridLengthType
        {
            None = 0,
            Pixel = 1,
            Auto = 2,
            Star = 4
        }

        internal static GridLengthType ToGridLengthType(GridUnitType gridUnitType)
        {
            return gridUnitType switch
            {
                GridUnitType.Pixel => GridLengthType.Pixel,
                GridUnitType.Star => GridLengthType.Star,
                GridUnitType.Auto => GridLengthType.Auto,
                _ => GridLengthType.None,
            };
        }

        internal static bool IsStar(GridLengthType gridLengthType)
        {
            return (gridLengthType & GridLengthType.Star) == GridLengthType.Star;
        }

        internal abstract class RowColumnDefinitionInfo
        {
            public double Size { get; set; }

            public void Update(double size)
            {
                if (size > Size)
                {
                    Size = size;
                }
            }

            public abstract bool IsAuto { get; }
            public abstract bool IsStar { get; }

            public abstract GridLength GridLength { get; }
        }

        internal class ColumnDefinitionInfo : RowColumnDefinitionInfo
        {
            public IColumnDefinition ColumnDefinition { get; set; }

            public override bool IsAuto => ColumnDefinition.Width.IsAuto;
            public override bool IsStar => ColumnDefinition.Width.IsStar;
            public override GridLength GridLength => ColumnDefinition.Width;

            public ColumnDefinitionInfo(IColumnDefinition columnDefinition)
            {
                ColumnDefinition = columnDefinition;
                if (columnDefinition.Width.IsAbsolute)
                {
                    Size = columnDefinition.Width.Value;
                }
            }
        }

        internal class RowDefinitionInfo : RowColumnDefinitionInfo
        {
            public IRowDefinition RowDefinition { get; set; }

            public override bool IsAuto => RowDefinition.Height.IsAuto;
            public override bool IsStar => RowDefinition.Height.IsStar;
            public override GridLength GridLength => RowDefinition.Height;

            public RowDefinitionInfo(IRowDefinition rowDefinition)
            {
                RowDefinition = rowDefinition;
                if (rowDefinition.Height.IsAbsolute)
                {
                    Size = rowDefinition.Height.Value;
                }
            }
        }
    }
}
