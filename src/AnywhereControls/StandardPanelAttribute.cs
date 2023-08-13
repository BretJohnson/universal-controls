using System;

namespace AnywhereControls
{
    /// <summary>
    /// Designate the interface as Standard Panel - a special type of .NET Standard
    /// Control used just for layout. There should be a matching LayoutManager class
    /// for the implementation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class StandardPanelAttribute : Attribute
    {
    }
}
