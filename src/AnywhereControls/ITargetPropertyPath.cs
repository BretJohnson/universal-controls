using System.ComponentModel;

namespace Microsoft.StandardUI
{
    /// <summary>
    /// Represents the path to a property on a target element.
    /// </summary>
    [UIModelObject]
    public interface ITargetPropertyPath : IUIObject
    {
        /// <summary>
        /// Gets or sets the path to the property on the target element.
        /// </summary>
        [DefaultValue(null)]
        public IPropertyPath Property { get; set; }

        /// <summary>
        /// Gets or sets the object that contains the property described by Path.
        /// </summary>
        [DefaultValue(null)]
        public object Target { get; set; }
    }
}
