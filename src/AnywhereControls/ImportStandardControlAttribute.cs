using System;

namespace Microsoft.StandardUI
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ImportStandardControlAttribute : Attribute
    {
        public Type InterfaceType { get; }

        public ImportStandardControlAttribute(Type interfaceType)
        {
            InterfaceType = interfaceType;
        }
    }
}
