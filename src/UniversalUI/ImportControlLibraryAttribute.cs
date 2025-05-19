using System;

namespace AnywhereUI
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ImportControlLibraryAttribute : Attribute
    {
        public Type ControlLibraryType { get; }

        public ImportControlLibraryAttribute(Type controlLibraryType)
        {
            ControlLibraryType = controlLibraryType;
        }
    }
}
