using System;

namespace UniversalUI
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ImportAnywhereControlAttribute : Attribute
    {
        public Type InterfaceType { get; }

        public ImportAnywhereControlAttribute(Type interfaceType)
        {
            InterfaceType = interfaceType;
        }
    }
}
