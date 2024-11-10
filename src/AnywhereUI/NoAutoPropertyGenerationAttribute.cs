using System;

namespace AnywhereControls
{
    /// <summary>
    /// This attribute, when set on a native control class (e.g. a WPF control
    /// class with [WpfStandardUIElement]) disables disables automatic property
    /// source generation for the specified property. It can be used when the
    /// property is provided by the base class, thus no new property need be
    /// generated. It can also be used when the property registration should
    /// be customized beyond what the source generator provides, allowing
    /// the property to be manually registered however is appropriate.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class NoAutoPropertyGenerationAttribute : Attribute
    {
        /// <summary>
        /// The name of the property for which autogeneration should be disabled
        /// </summary>
        public string Name { get; }

        public NoAutoPropertyGenerationAttribute(string name)
        {
            Name = name;
        }
    }
}
