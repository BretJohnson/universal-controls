using System;

namespace AnywhereControls
{
    /// <summary>
    /// Designate the interface as a .NET Standard Control. There should be a matching
    /// implementation class.
    /// 
    /// Controls which are "abstract", not intended to be instantiated directly but only
    /// serving as the ancestor type of other controls, shoulnd't have the attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class StandardControlAttribute : Attribute
    {
    }
}
