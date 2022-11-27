using System;

namespace Microsoft.ComponentModelEx
{
    /// <summary>
    /// An attribute that specifies this is an example, for a control or other UI.
    /// Examples can be shown in a gallery viwer and doc.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class UIExampleAttribute : Attribute
    {
        /// <summary>
        /// Optional description for the example, which can be shown in the viewer.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Creates a new content property attriubte that indicates that associated
        /// class does not have a content property attribute. This allows a descendent
        /// to remove an ancestor's declaration of a content property attribute.
        /// </summary>
        public UIExampleAttribute()
        {
        }

        public UIExampleAttribute(string description)
        {
            Description = description;
        }
    }
}
