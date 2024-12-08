using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using AnywhereUI.SourceGenerator.UIFrameworks;

namespace AnywhereUI.SourceGenerator
{
    public class ControlLibrary
    {
        public Context Context { get; }
        public string LibraryNamespace { get; }
        public string LibraryName { get; }
        public List<UIObjectType> UIObjectTypes { get; }

        public ControlLibrary(Context context, IAssemblySymbol assembly)
        {
            Context = context;

            // Get all the interfaces with attributes indicating that they should generate source
            // (e.g. [AnywhereControl], [UIElement], etc.). Also get the control library class.
            var gatherTypesVisitor = new GatherTypesVisitor(context);
            gatherTypesVisitor.Visit(assembly.GlobalNamespace);
            //assembly.Accept(gatherTypesVisitor);

            if (assembly.Name == "AnywhereUI.CommonTypes")
            {
                LibraryName = "AnywhereUICommonTypes";
                LibraryNamespace = "AnywhereUI";
            }
            else
            {
                INamedTypeSymbol? controlLibraryClass = gatherTypesVisitor.ControlLibraryClass;
                if (controlLibraryClass == null)
                    throw UserVisibleErrors.MissingControlLibraryClass();

                string typeName = controlLibraryClass.Name;

                string requiredSuffix = "ControlLibrary";
                if (!typeName.EndsWith(requiredSuffix))
                    throw UserVisibleErrors.ControlLibraryNameInvalid(controlLibraryClass);

                LibraryName = typeName.Substring(0, typeName.Length - requiredSuffix.Length);
                LibraryNamespace = Utils.GetNamespaceFullName(controlLibraryClass.ContainingNamespace);
            }

            UIObjectTypes = gatherTypesVisitor.UIObjectTypes;
        }

        public ControlLibrary(Context context, INamedTypeSymbol controlLibraryClass, List<UIObjectType> uiObjectTypes)
        {
            Context = context;
            UIObjectTypes = uiObjectTypes;

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
            usings.AddNamespace("AnywhereUI");

            members.AddLines(
                "private static Func<T> UninitializedCreator<T>() =>");
            using (members.Indent())
            {
                members.AddLines(
                    $"() => throw new FactoryNotInitializedException(\"{LibraryName}\");");
            }
            members.AddBlankLine();

            bool anySingletons = false;
            foreach (UIObjectType uiObjectType in UIObjectTypes)
            {
                if (uiObjectType.UIObjectKind == UIObjectKind.UISingleton)
                {
                    anySingletons = true;
                    continue;
                }

                usings.AddNamespace(uiObjectType.NamespaceName);
                members.AddLine(
                    $"public static Func<{uiObjectType.Name}> {uiObjectType.FrameworkClassName}Creator {{ get; set; }} = UninitializedCreator<{uiObjectType.Name}>();");
            }

            if (anySingletons)
            {
                members.AddBlankLine();
                members.AddLine("// Singletons");

                foreach (UIObjectType uiObjectType in UIObjectTypes)
                {
                    if (uiObjectType.UIObjectKind != UIObjectKind.UISingleton)
                    {
                        continue;
                    }

                    usings.AddNamespace(uiObjectType.NamespaceName);
                    members.AddLine(
                        $"public static {uiObjectType.Name} {uiObjectType.FrameworkClassName} {{ get; set; }}");
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
            foreach (UIObjectType uiObjectType in UIObjectTypes)
            {
                if (uiObjectType.UIObjectKind == UIObjectKind.UISingleton)
                {
                    anySingletons = true;
                    continue;
                }

                usings.AddNamespace(uiObjectType.NamespaceName);
                members.AddLine(
                    $"public static {uiObjectType.Name} {uiObjectType.FrameworkClassName}() => {LibraryName}Factory.{uiObjectType.FrameworkClassName}Creator();");
            }

            if (anySingletons)
            {
                members.AddBlankLine();
                members.AddLine("// Singletons");

                foreach (UIObjectType uiObjectType in UIObjectTypes)
                {
                    if (uiObjectType.UIObjectKind != UIObjectKind.UISingleton)
                    {
                        continue;
                    }

                    usings.AddNamespace(uiObjectType.NamespaceName);
                    members.AddLine(
                        $"public static {uiObjectType.Name} {uiObjectType.FrameworkClassName} => {LibraryName}Factory.{uiObjectType.FrameworkClassName};");
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
                    foreach (UIObjectType uiObjectType in UIObjectTypes)
                    {
                        if (uiObjectType.UIObjectKind == UIObjectKind.UISingleton)
                        {
                            anySingletons = true;
                            continue;
                        }

                        members.AddLine(
                            $"{LibraryName}Factory.{uiObjectType.FrameworkClassName}Creator = () => new {uiObjectType.GetFullFrameworkClassName(uiFramework)}();");
                    }

                    if (anySingletons)
                    {
                        members.AddBlankLine();
                        members.AddLine("// Singletons");

                        foreach (UIObjectType uiObjectType in UIObjectTypes)
                        {
                            if (uiObjectType.UIObjectKind != UIObjectKind.UISingleton)
                            {
                                continue;
                            }

                            members.AddLine(
                                $"{LibraryName}Factory.{uiObjectType.FrameworkClassName} = new {uiObjectType.GetFullFrameworkClassName(uiFramework)}();");
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
            foreach (UIObjectType uiObjectType in UIObjectTypes)
            {
                uiObjectType.GenerateExtensionsClass();
            }
        }

        public void GenerateControlClasses(UIFramework uiFramework)
        {
            foreach (UIObjectType uiObjectType in UIObjectTypes)
            {
                uiObjectType.Generate(uiFramework);
            }
        }

        private class GatherTypesVisitor : SymbolVisitor
        {
            private readonly Context _context;
            private INamedTypeSymbol? _controlLibraryClass = null;
            private readonly List<UIObjectType> _uiObjectTypes = new();

            public GatherTypesVisitor(Context context)
            {
                _context = context;
            }

            public List<UIObjectType> UIObjectTypes => _uiObjectTypes;

            public INamedTypeSymbol? ControlLibraryClass => _controlLibraryClass;

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
                    UIObjectKind objectKind = UIObjectType.IdentifyObjectKind(type);
                    if (objectKind != UIObjectKind.Unspecified)
                    {
                        var uiObjectType = new UIObjectType(_context, type);
                        _uiObjectTypes.Add(uiObjectType);
                    }
                    else
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
                }
                else if (type.TypeKind == TypeKind.Interface)
                {
                    UIObjectKind objectKind = UIObjectType.IdentifyObjectKind(type);
                    if (objectKind != UIObjectKind.Unspecified)
                    {
                        var uiObjectType = new UIObjectType(_context, type);
                        _uiObjectTypes.Add(uiObjectType);
                    }
                }
            }
        }
    }
}
