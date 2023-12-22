using System;
using Microsoft.CodeAnalysis;

namespace AnywhereControls.SourceGenerator
{
    public class TypeName
    {
        public string Namespace { get; }

        public string Name { get; }

        /// <summary>
        /// Get the type name without the "Attribute" suffix, appropriate for using in C# code that uses the attribute.
        /// </summary>
        public string AttributeName
        {
            get
            {
                string attributeSuffix = "Attribute";
                if (! Name.EndsWith(attributeSuffix))
                {
                    throw new InvalidOperationException($"Type name doesn't end with \"{attributeSuffix}\" as expected: {Name}");
                }
                return Name.Substring(0, Name.Length - attributeSuffix.Length);
            }
        }

        public string FullName => Namespace.Length > 0 ? $"{Namespace}.{Name}" : Name;

        public string AtributeFullName => Namespace.Length > 0 ? $"{Namespace}.{AttributeName}" : AttributeName;

        public TypeName(string @namespace, string type)
        {
            Namespace = @namespace;
            Name = type;
        }

        public TypeName(INamedTypeSymbol namedType)
        {
            Namespace = Utils.GetNamespaceFullName(namedType.ContainingNamespace);
            Name = namedType.Name;
        }
    }
}
