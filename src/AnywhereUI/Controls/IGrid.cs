using System.ComponentModel;

namespace AnywhereUI.Controls
{
    [StandardPanel]
    public interface IGrid : IPanel
    {
        /// <summary>
        /// List of column definitions defined on this instance of the grid.
        /// </summary>
        public IUICollection<IColumnDefinition> ColumnDefinitions { get; }

        /// <summary>
        /// List of row definitions defined on this instance of the grid.
        /// </summary>
        public IUICollection<IRowDefinition> RowDefinitions { get; }

        /// <summary>
        /// Uniform distance between grid columns.
        /// </summary>
        [DefaultValue(0.0)]
        public double ColumnSpacing { get; set; }

        /// <summary>
        /// Uniform distance between grid rows.
        /// </summary>
        [DefaultValue(0.0)]
        public double RowSpacing { get; set; }
    }
}
