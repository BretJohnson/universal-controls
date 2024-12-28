using System;

namespace AnywhereUI
{
    /// <summary>
    /// Designate the class as a .NET Anwhere UIElement. This is similar to
    /// the <see cref="AnywhereControlAttribute"/> attribute, but used for
    /// lighter weight UI elements, which aren't templated controls.
    /// 
    /// Classes which are not intended to be instantiated directly but only serving
    /// as the ancestor type of other UI elements shoulnd't have the attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AnywhereUIElementAttribute : Attribute
    {
    }
}
