using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.StandardUI.SourceGenerator.UIFrameworks;

namespace Microsoft.StandardUI.SourceGenerator
{
    public class ControlLibrary
    {
        public Context Context { get; }
        public string LibraryNamespace { get; }
        public string LibraryName { get; }
        public List<Interface> Interfaces { get; }

        public ControlLibrary(Context context, IAssemblySymbol assembly)
        {
            Context = context;

            // Get all the interfaces with attributes indicating that they should generate source
            // (e.g. [StandardControl], [UIElement], etc.). Also get the control library class.
            var gatherTypesVisitor = new GatherTypesVisitor(context);
            gatherTypesVisitor.Visit(assembly.GlobalNamespace);
            //assembly.Accept(gatherTypesVisitor);

            INamedTypeSymbol controlLibraryClass = gatherTypesVisitor.ControlLibraryClass;
            if (controlLibraryClass == null)
                throw UserVisibleErrors.MissingControlLibraryClass();

            string typeName = controlLibraryClass.Name;

            string requiredSuffix = "ControlLibrary";
            if (!typeName.EndsWith(requiredSuffix))
                throw UserVisibleErrors.ControlLibraryNameInvalid(controlLibraryClass);

            LibraryName = typeName.Substring(0, typeName.Length - requiredSuffix.Length);
            LibraryNamespace = Utils.GetNamespaceFullName(controlLibraryClass.ContainingNamespace);
            Interfaces = gatherTypesVisitor.Interfaces;
        }

        public ControlLibrary(Context context, INamedTypeSymbol controlLibraryClass, List<Interface> interfaces)
        {
            Context = context;
            Interfaces = interfaces;

            string typeName = controlLibraryClass.Name;

            string requiredSuffix = "ControlLibrary";
            if (! typeName.EndsWith(requiredSuffix))
                throw UserVisibleErrors.ControlLibraryNameInvalid(controlLibraryClass);

            LibraryName = typeName.Substring(0, typeName.Length - requiredSuffix.Length);
            LibraryNamespace = Utils.GetNamespaceFullName(controlLibraryClass.ContainingNamespace);
        }

        public void GenerateFactoryClass()
        {
            var factoryClassSource = new ClassSource(Context,
                namespaceName: LibraryNamespace,
                className: $"{LibraryName}Factory",
                isStatic: true);

            Usings usings = factoryClassSource.Usings;
            Source members = factoryClassSource.StaticMethods;

            usings.AddNamespace("System");
            usings.AddNamespace("Microsoft.StandardUI");

            members.AddLines(
                "private static Func<T> UninitializedCreator<T>() =>");
            using (members.Indent())
            {
                members.AddLines(
                    $"() => throw new FactoryNotInitializedException(\"{LibraryName}\");");
            }
            members.AddBlankLine();

            bool anySingletons = false;
            foreach (Interface intface in Interfaces)
            {
                if (intface.Purpose == InterfacePurpose.UISingleton)
                {
                    anySingletons = true;
                    continue;
                }

                usings.AddNamespace(intface.NamespaceName);
                members.AddLine(
                    $"public static Func<{intface.Name}> {intface.FrameworkClassName}Creator {{ get; set; }} = UninitializedCreator<{intface.Name}>();");
            }

            if (anySingletons)
            {
                members.AddBlankLine();
                members.AddLine("// Singletons");

                foreach (Interface intface in Interfaces)
                {
                    if (intface.Purpose != InterfacePurpose.UISingleton)
                    {
                        continue;
                    }

                    usings.AddNamespace(intface.NamespaceName);
                    members.AddLine(
                        $"public static {intface.Name} {intface.FrameworkClassName} {{ get; set; }}");
                }
            }

            factoryClassSource.AddToOutput(null);
        }

        public void GenerateStaticsClass()
        {
            var factoryClassSource = new ClassSource(Context,
                namespaceName: LibraryNamespace,
                className: $"{LibraryName}Statics",
                isStatic: true);

            Usings usings = factoryClassSource.Usings;
            Source members = factoryClassSource.StaticMethods;

            bool anySingletons = false;
            foreach (Interface intface in Interfaces)
            {
                if (intface.Purpose == InterfacePurpose.UISingleton)
                {
                    anySingletons = true;
                    continue;
                }

                usings.AddNamespace(intface.NamespaceName);
                members.AddLine(
                    $"public static {intface.Name} {intface.FrameworkClassName}() => {LibraryName}Factory.{intface.FrameworkClassName}Creator();");
            }

            if (anySingletons)
            {
                members.AddBlankLine();
                members.AddLine("// Singletons");

                foreach (Interface intface in Interfaces)
                {
                    if (intface.Purpose != InterfacePurpose.UISingleton)
                    {
                        continue;
                    }

                    usings.AddNamespace(intface.NamespaceName);
                    members.AddLine(
                        $"public static {intface.Name} {intface.FrameworkClassName} => {LibraryName}Factory.{intface.FrameworkClassName};");
                }
            }

            factoryClassSource.AddToOutput(null);
        }

        public void GenerateLibraryClass(UIFramework uiFramework)
        {
            var libraryClassSource = new ClassSource(Context,
                namespaceName: $"{LibraryNamespace}.{uiFramework.NamespaceSuffix}",
                className: $"{LibraryName}Library",
                isStatic: true);

            Usings usings = libraryClassSource.Usings;
            Source members = libraryClassSource.StaticMethods;

            // Add using for library Factory class
            usings.AddNamespace(LibraryNamespace);

            members.AddLine(
                $"public static bool Initialized {{ get; private set; }}");

            members.AddBlankLine();

            // Add the Initialize method
            members.AddLines(
                "public static void Initialize()",
                "{");
            using (members.Indent())
            {
                members.AddLines(
                    "if (!Initialized)",
                    "{");
                bool anySingletons = false;
                using (members.Indent())
                {
                    foreach (Interface intface in Interfaces)
                    {
                        if (intface.Purpose == InterfacePurpose.UISingleton)
                        {
                            anySingletons = true;
                            continue;
                        }

                        members.AddLine(
                            $"{LibraryName}Factory.{intface.FrameworkClassName}Creator = () => new {intface.GetFullFrameworkClassName(uiFramework)}();");
                    }

                    if (anySingletons)
                    {
                        members.AddBlankLine();
                        members.AddLine("// Singletons");

                        foreach (Interface intface in Interfaces)
                        {
                            if (intface.Purpose != InterfacePurpose.UISingleton)
                            {
                                continue;
                            }

                            members.AddLine(
                                $"{LibraryName}Factory.{intface.FrameworkClassName} = new {intface.GetFullFrameworkClassName(uiFramework)}();");
                        }
                    }
                }
                members.AddLine(
                    "}");
            }
            members.AddLine(
                "}");

            libraryClassSource.AddToOutput(null);
        }

        public void GenerateExtensionsClasses()
        {
            foreach (var intface in Interfaces)
            {
                intface.GenerateExtensionsClass();
            }
        }

        public void GenerateControlClasses(UIFramework uiFramework)
        {
            foreach (Interface intface in Interfaces)
            {
                intface.Generate(uiFramework);
            }
        }

        private class GatherTypesVisitor : SymbolVisitor
        {
            private readonly Context _context;
            private INamedTypeSymbol? _controlLibraryClass = null;
            private readonly List<Interface> _interfaces = new();

            public GatherTypesVisitor(Context context)
            {
                _context = context;
            }

            public List<Interface> Interfaces => _interfaces;

            public INamedTypeSymbol ControlLibraryClass => _controlLibraryClass;

            public override void VisitNamespace(INamespaceSymbol symbol)
            {
                foreach (INamespaceOrTypeSymbol childSymbol in symbol.GetMembers())
                {
                    childSymbol.Accept(this);
                }
            }

            public override void VisitNamedType(INamedTypeSymbol type)
            {
                if (type.TypeKind == TypeKind.Class)
                {
                    foreach (AttributeData attribute in type.GetAttributes())
                    {
                        INamedTypeSymbol? attributeClass = attribute.AttributeClass;
                        if (attributeClass == null)
                            continue;

                        string attributeTypeFullName = Utils.GetTypeFullName(attributeClass);

                        if (attributeTypeFullName == KnownTypes.ControlLibraryAttribute)
                            _controlLibraryClass = type;
                    }
                }
                else if (type.TypeKind == TypeKind.Interface)
                {
                    InterfacePurpose interfacePuprpose = Interface.IdentifyPurpose(type);
                    if (interfacePuprpose != InterfacePurpose.Unspecified)
                    {
                        var intface = new Interface(_context, type);
                        _interfaces.Add(intface);
                    }
                }
            }
        }
    }
}
