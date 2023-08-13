using System;

namespace Microsoft.StandardUI
{
    /// <summary>
    /// Designate interface as a Standard UI Element, triggering source generation
    /// and inclusion in control library.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class StandardUIElementAttribute : Attribute
    {
    }
}
