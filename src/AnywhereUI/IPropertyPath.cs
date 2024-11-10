using System.ComponentModel;

namespace AnywhereControls
{
    /// <summary>
    /// Implements a data structure for describing a property as a path below another property, or
    /// below an owning type. Property paths are used in data binding to objects.
    /// </summary>
    [UIModelObject]
    public interface IPropertyPath : IUIObject
    {
        /// <summary>
        /// Gets the path value held by this PropertyPath.
        /// </summary>
        [DefaultValue("")]
        public string Path { get; }
    }
}
