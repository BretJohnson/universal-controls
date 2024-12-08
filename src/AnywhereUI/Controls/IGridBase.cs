using System.ComponentModel;

namespace AnywhereUI.Controls
{
    [UIModelObject]
    public interface IGridBase : IUIElement
    {
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
