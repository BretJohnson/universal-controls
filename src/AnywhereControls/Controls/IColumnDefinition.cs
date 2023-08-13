using System.ComponentModel;

namespace Microsoft.StandardUI.Controls
{
    [UIModelObject]
    public interface IColumnDefinition : IUIObject
    {
        /// <summary>
        /// The width of the column. The default value is a GridLength representing a "1*" sizing.
        /// </summary>
        GridLength Width { get; set; }

        /// <summary>
        /// The minimum width of the column definition, in pixels.
        /// </summary>
        [DefaultValue(0.0)]
        public double MinWidth { get; set; }

        /// <summary>
        /// The maximum width of the column definition, in pixels. The default is PositiveInfinity.
        /// </summary>
        [DefaultValue(double.PositiveInfinity)]
        public double MaxWidth { get; set; }

        /// <summary>
        /// The actual calculated width of the column definition.
        /// </summary>
        [DefaultValue(0.0)]
        public double ActualWidth { get; }
    }
}
