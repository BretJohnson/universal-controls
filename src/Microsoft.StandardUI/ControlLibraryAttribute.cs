using System;

namespace Microsoft.StandardUI
{
    /// <summary>
    /// Designate the assembly as containing .NET Standard Controls and specify
    /// associated metadata for the library.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ControlLibraryAttribute : Attribute
    {
    }
}
