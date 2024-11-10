using System;

namespace AnywhereControls;

/// <summary>
/// An attribute that specifies which property the direct content of a XAML
/// element (or equivalent markup) should be associated with.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = false, Inherited = true)]
public sealed class ContentPropertyAttribute : Attribute
{
    /// <summary>
    /// The name of the property that is associated with direct content
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// Creates a new content property attriubte that indicates that associated
    /// class does not have a content property attribute. This allows a descendent
    /// to remove an ancestor's declaration of a content property attribute.
    /// </summary>
    public ContentPropertyAttribute()
    {
    }

    /// <summary>
    /// Creates a new content property attribute that associates the direct content
    /// of a XAML element (or equiavalent markup) with the property of the given name
    /// </summary>
    /// <param name="name">The property to associate to direct content</param>
    public ContentPropertyAttribute(string name)
    {
        Name = name;
    }
}
