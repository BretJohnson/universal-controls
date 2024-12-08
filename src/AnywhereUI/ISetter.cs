using System.ComponentModel;

namespace AnywhereUI
{
    [UIModelObject]
    public interface ISetter : IUIObject
    {
        /// <summary>
        /// Gets or sets the property to apply the Value to.
        /// </summary>
        [DefaultValue(null)]
        public IUIProperty? Property { get; set; }

        /// <summary>
        /// Gets or sets the path of a property on a target element to apply the Value to.
        /// </summary>
        [DefaultValue(null)]
        public ITargetPropertyPath Target { get; set; }

        /// <summary>
        /// Gets or sets the value to apply to the property that is specified by the Setter.
        /// </summary>
        [DefaultValue(null)]
        public object Value { get; set; }
    }
}
