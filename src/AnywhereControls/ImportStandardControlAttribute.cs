using System;

namespace AnywhereControls
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
