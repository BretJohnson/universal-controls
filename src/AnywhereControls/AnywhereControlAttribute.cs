using System;

namespace AnywhereControls
{
    /// <summary>
    /// Designate the class as a .NET Anwhere Control.
    /// 
    /// Control classes which are not intended to be instantiated directly but only
    /// serving as the ancestor type of other controls shoulnd't have the attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AnywhereControlAttribute : Attribute
    {
    }
}
