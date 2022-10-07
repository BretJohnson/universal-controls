using System.ComponentModel;

namespace Microsoft.StandardUI.Controls.Primitives
{
    [UIModelObject]
    public interface IRangeBase : IUIElement
    {
        /// <summary>
        /// The value to add to or subtract from the <see cref="Value"/> of the range element.
        /// </summary>
        [DefaultValue(1.0)]
        public double LargeChange { get; set; }

        /// <summary>
        /// The highest possible <see cref="Value"/> of the range element.
        /// </summary>
        [DefaultValue(1.0)]
        public double Maximum { get; set; }

        /// <summary>
        /// Minimum possible <see cref="Value"/> of the range element.
        /// </summary>
        [DefaultValue(0.0)]
        public double Minimum { get; set; }

        /// <summary>
        /// The value to be added to or subtracted from the <see cref="Value"/> of the range element.
        /// </summary>
        [DefaultValue(0.1)]
        public double SmallChange { get; set; }

        /// <summary>
        /// The current setting of the range element, which may be coerced.
        /// </summary>
        [DefaultValue(0.0)]
        public double Value { get; set; }
    }
}
