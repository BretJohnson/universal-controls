using System.ComponentModel;

namespace AnywhereUI.Controls
{
    [UIModelObject]
    public interface IRowDefinition : IUIObject
    {
        /// <summary>
        /// The height of the row. The default value is a GridLength representing a "1*" sizing.
        /// </summary>
        GridLength Height { get; set; }

        /// <summary>
        /// The minimum height of the row definition, in pixels.
        /// </summary>
        [DefaultValue(0.0)]
        public double MinHeight { get; set; }

        /// <summary>
        /// The maximum height of the row definition, in pixels. The default is PositiveInfinity.
        /// </summary>
        [DefaultValue(double.PositiveInfinity)]
        public double MaxHeight { get; set; }

        /// <summary>
        /// The actual calculated height of the row definition.
        /// </summary>
        [DefaultValue(0.0)]
        public double ActualHeight { get; }
    }
}
