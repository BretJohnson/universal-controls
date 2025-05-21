using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using UniversalUI.SourceGenerator.UIFrameworks;

namespace UniversalUI.SourceGenerator
{
    public class UIObjectType
    {
        public Context Context { get; }
        public INamedTypeSymbol Type { get; }
        public UIObjectKind UIObjectKind { get; }
        public INamespaceSymbol Namespace { get; }
        public string NamespaceName { get; }
        public string GetFrameworkNamespaceName(UIFramework uiFramework) => uiFramework.ToFrameworkNamespaceName(Namespace);
        public string FrameworkClassName { get; }
        public string GetFullFrameworkClassName(UIFramework uiFramework) => $"{GetFrameworkNamespaceName(uiFramework)}.{FrameworkClassName}";
        public INamedTypeSymbol? AttachedType { get; }
        public string Name { get; }
        public string VariableName { get; }
        public INamedTypeSymbol? LayoutManagerType { get; }
        public INamedTypeSymbol? AnywhereControlSharedClass { get; }
        public string? ContentPropertyName { get; }

        public bool IsInterface => Type.TypeKind == TypeKind.Interface;
        public string BaseName => IsInterface ? Name.Substring(1) : Name;
        public bool IsThisType(string typeName) => Utils.IsThisType(Type, typeName);

        public bool IsDrawableObject
        {
            get
            {
                if (IsThisType(KnownTypes.ITextBlock))
                    return true;

                if (Type is not INamedTypeSymbol namedType)
                    return false;

                foreach (INamedTypeSymbol intface in namedType.Interfaces)
                {
                    if (Utils.IsThisType(intface, KnownTypes.IShape))
                        return true;
                }

                return false;
            }
        }

        public static UIObjectKind IdentifyObjectKind(INamedTypeSymbol type)
        {
            // Hardcode the purpose for CommonUI.IUIElement
            if (Utils.IsThisType(type, KnownTypes.IUIElement))
                return UIObjectKind.StandardUIElement;

            // Skip ...Attached interfaces, processing them when their paired main interface is processed instead
            if (type.Name.EndsWith("Attached"))
                return UIObjectKind.Unspecified;

            foreach (AttributeData attribute in type.GetAttributes())
            {
                INamedTypeSymbol? attributeClass = attribute.AttributeClass;
                if (attributeClass == null)
                    continue;

                string attributeTypeFullName = Utils.GetTypeFullName(attributeClass);

                if (attributeTypeFullName == KnownTypes.UIModelAttribute)
                    return UIObjectKind.StandardUIObject;
                else if (attributeTypeFullName == KnownTypes.StandardUISingletonAttribute)
                    return UIObjectKind.UISingleton;
                else if (attributeTypeFullName == KnownTypes.UIObjectAttribute)
                    return UIObjectKind.UIObject;
                else if (attributeTypeFullName == KnownTypes.StandardUIElementAttribute)
                    return UIObjectKind.StandardUIElement;
                else if (attributeTypeFullName == KnownTypes.StandardPanelAttribute)
                    return UIObjectKind.StandardPanel;
                else if (attributeTypeFullName == KnownTypes.AnywhereControlAttribute)
                    return UIObjectKind.AnywhereControl;
                else continue;
            }

            return UIObjectKind.Unspecified;
        }

        public UIObjectType(Context context, INamedTypeSymbol type)
        {
            Context = context;

            Type = type;
            Name = type.Name;
            if (IsInterface && !Name.StartsWith("I"))
                throw UserVisibleErrors.StandardUIInterfaceMustStartWithI(type);

            UIObjectKind = IdentifyObjectKind(type);

            FrameworkClassName = BaseName;

            // Form the default variable name for the interface by dropping the "I" and lower casing the first letter(s) after (ICanvas => canvas)
            VariableName = Utils.GeTypeVariableName(Type);

            Namespace = Type.ContainingNamespace;
            NamespaceName = Utils.GetNamespaceFullName(Namespace);

            // Get attached type, if it exists
            string fullNameAttached = Utils.GetTypeFullName(type) + "Attached";
            AttachedType = Context.Compilation.GetTypeByMetadataName(fullNameAttached);

            if (UIObjectKind == UIObjectKind.StandardPanel)
            {
                string layoutManagerFullName = $"{NamespaceName}.{BaseName}LayoutManager";
                LayoutManagerType = Context.Compilation.GetTypeByMetadataName(layoutManagerFullName);

                if (LayoutManagerType == null)
                    throw UserVisibleErrors.NoLayoutManagerClassFound(layoutManagerFullName, Name);
            }

            // Get content property name or null
            ContentPropertyName = Utils.GetAttributeStringValue(type, KnownTypes.ContentPropertyAttribute);
        }

        public void Generate(UIFramework uiFramework, ISet<string>? noAutoGenerationProperties = null)
        {
            if (IsThisType(KnownTypes.IUIElement))
            {
                uiFramework.GenerateBuiltInIUIElementPartialClasses();
                return;
            }
            else if (IsThisType(KnownTypes.IUIObject))
            {
                // UIObject has a hand-written implementation, so don't generate anything for it
                return;
            }

            // Code is only generated for the interface types below
            if (UIObjectKind != UIObjectKind.AnywhereControl &&
                UIObjectKind != UIObjectKind.StandardPanel &&
                UIObjectKind != UIObjectKind.StandardUIObject &&
                UIObjectKind != UIObjectKind.UIObject)
                return;

            string generatedFrom = $"{Name}.cs";

            string frameworkNamespaceName = GetFrameworkNamespaceName(uiFramework);

            var mainClassSource = new ClassSource(Context,
                generatedFrom: generatedFrom,
                namespaceName: frameworkNamespaceName,
                className: FrameworkClassName);

            if (UIObjectKind == UIObjectKind.AnywhereControl)
            {
                string baseClass = Utils.GetTypeFullName(Type);
                mainClassSource.DerivedFrom = baseClass;
            }
            else
            {
                string? destinationBaseClass = GetOutputBaseClass(uiFramework, mainClassSource.Usings);
                if (destinationBaseClass == null)
                    mainClassSource.DerivedFrom = Name;
                else
                    mainClassSource.DerivedFrom = $"{destinationBaseClass}, {Name}";
            }

            if (IsDrawableObject)
            {
                mainClassSource.Usings.AddNamespace("UniversalUI");
                mainClassSource.DerivedFrom += ", IDrawable";
            }

            uiFramework.GenerateAttributes(this, mainClassSource);

            // Add the property descriptors and accessors
            var properties = new List<Property>();
            GenerateTypeProperties(this, uiFramework, noAutoGenerationProperties, properties, mainClassSource);

            // If the interface has multiple parent interfaces, the generated superclass will implement the properties
            // for the first interface (that's the typical case), but if there are any additional interfaces, properties
            // for them must be directly implemented here
            bool first = true;
            foreach (INamedTypeSymbol additionalInterfaceType in Type.Interfaces)
            {
                // TODO: Remove this once Roslyn source generator issue is tracked down so it's not needed.
                if (UIObjectKind == UIObjectKind.AnywhereControl)
                    continue;

                if (first)
                {
                    first = false;
                    continue;
                }

                var additionalUIObjectType = new UIObjectType(Context, additionalInterfaceType);
                GenerateTypeProperties(additionalUIObjectType, uiFramework, noAutoGenerationProperties, properties, mainClassSource);
            }

            // If there are any attached properties, add the property descriptors and accessors for them
            ClassSource? attachedClassSource = null;
            if (AttachedType != null)
            {
                attachedClassSource = new ClassSource(Context,
                    generatedFrom: generatedFrom,
                    namespaceName: frameworkNamespaceName,
                    className: FrameworkClassName + "Attached",
                    derivedFrom: AttachedType.Name);

                attachedClassSource.Usings.AddTypeNamespace(Type);

                foreach (ISymbol member in AttachedType.GetMembers())
                {
                    if (member is not IMethodSymbol getterMethod)
                        continue;

                    // We just process the Get 
                    string methodName = getterMethod.Name;
                    if (!methodName.StartsWith("Get"))
                    {
                        if (!methodName.StartsWith("Set"))
                            throw UserVisibleErrors.AttachedTypeMethodMustStartWithGetOrSet(AttachedType.Name, methodName);
                        else continue;
                    }

                    string propertyName = methodName.Substring("Get".Length);
                    string setterMethodName = "Set" + propertyName;
                    IMethodSymbol? setterMethod = (IMethodSymbol?)AttachedType.GetMembers(setterMethodName).FirstOrDefault();

                    var attachedProperty = new AttachedProperty(Context, this, AttachedType, getterMethod, setterMethod);
                    uiFramework.GenerateAttachedProperty(attachedProperty, mainClassSource, attachedClassSource);
                }
            }

            // Add any other methods needed for particular special types
            if (IsDrawableObject)
                uiFramework.GenerateDrawableObjectMethods(this, mainClassSource.NonstaticMethods);

            if (IsThisType(KnownTypes.IPanel))
                uiFramework.GeneratePanelMethods(mainClassSource.NonstaticMethods);

            if (UIObjectKind == UIObjectKind.StandardPanel)
                uiFramework.GenerateStandardPanelLayoutMethods(LayoutManagerType!.Name, mainClassSource.NonstaticMethods);

            mainClassSource.Usings.AddTypeNamespace(Type);

#pragma warning disable CS8604 // Possible null reference argument.

            if (UIObjectKind == UIObjectKind.AnywhereControl)
            {
                /*
                string implementationFullTypeName = Utils.GetTypeFullName(AnywhereControlSharedType);
                mainClassSource.DefaultConstructorBody.AddLine(
                    $"InitImplementation(new {implementationFullTypeName}(this));");
                */
            }

#pragma warning restore CS8604

            mainClassSource.AddToOutput(uiFramework);

            if (AttachedType != null)
            {
                string attachedClassName = FrameworkClassName + "Attached";
                attachedClassSource!.StaticFields.AddLine($"public static {attachedClassName} Instance = new {attachedClassName}();");

                attachedClassSource.AddToOutput(uiFramework);
            }
        }

        public void GenerateNativeUIElementPartialClass(UIFramework uiFramework, ISet<string>? noAutoGenerationProperties,
            TypeName className, string? derivedFrom)
        {
            var classSource = new ClassSource(Context,
                namespaceName: className.Namespace,
                isPartial: true,
                className: className.Name,
                derivedFrom: derivedFrom,
                fileNameOverride: className.Name + ".UIElement");

            // Add the property descriptors and accessors
            var properties = new List<Property>();
            GenerateTypeProperties(this, uiFramework, noAutoGenerationProperties, properties, classSource);

            classSource.NonstaticMethods.AddBlankLineIfNonempty();
            classSource.NonstaticMethods.AddLine("// IUIElement methods");
            classSource.NonstaticMethods.AddBlankLine();
            uiFramework.GenerateIUIElementMethods(classSource);

            classSource.AddToOutput(uiFramework);
        }

        private static void GenerateTypeProperties(UIObjectType uiObjectType, UIFramework uiFramework, ISet<string>? noAutoGenerationProperties,
            List<Property> properties, ClassSource classSource)
        {
            if (uiObjectType.IsThisType("UniversalUI.Controls.ICanvas"))
            {
                classSource.Usings.AddTypeAlias("ICanvas = UniversalUI.Controls.ICanvas");
            }

            foreach (IPropertySymbol propertySymbol in uiObjectType.Type.GetMembers().Where(member => member.Kind == SymbolKind.Property))
            {
                if (noAutoGenerationProperties != null && noAutoGenerationProperties.Contains(propertySymbol.Name))
                    continue;

                var property = new Property(uiObjectType.Context, uiObjectType, propertySymbol);
                properties.Add(property);

                uiFramework.GenerateProperty(property, classSource);
            }
        }

        public void GenerateExtensionsClass()
        {
            var usings = new Usings(Context, NamespaceName);
            var properties = new List<Property>();
            var methods = new Source(Context, usings);
            var staticFields = new Source(Context, usings);

            // Add interface extension methods, allowing fluent style setters
            foreach (IPropertySymbol propertySymbol in Type.GetMembers().Where(member => member.Kind == SymbolKind.Property))
            {
                var property = new Property(Context, this, propertySymbol);
                properties.Add(property);

                property.GenerateExtensionClassMethods(methods);
            }

            // If there are any attached properties, add target extension methods for those too
            if (AttachedType != null)
            {
                string attachedClassName = FrameworkClassName + "Attached";
                usings.AddNamespace("System");

                staticFields.AddLines(
                    $"private static readonly Lazy<{AttachedType.Name}> s_{attachedClassName} = new Lazy<{AttachedType.Name}>(() => HostEnvironment.Factory.{attachedClassName}Instance);",
                    $"public static {AttachedType.Name} {attachedClassName}Instance => s_{attachedClassName}.Value;");

                methods.AddBlankLineIfNonempty();
                methods.AddLine("// Attached properties");

                foreach (ISymbol member in AttachedType.GetMembers())
                {
                    if (!(member is IMethodSymbol getterMethod))
                        continue;

                    // We just process the Get 
                    string methodName = getterMethod.Name;
                    if (!methodName.StartsWith("Get"))
                    {
                        if (!methodName.StartsWith("Set"))
                            throw UserVisibleErrors.AttachedTypeMethodMustStartWithGetOrSet(AttachedType.Name, methodName);
                        else continue;
                    }

                    string propertyName = methodName.Substring("Get".Length);
                    string setterMethodName = "Set" + propertyName;
                    IMethodSymbol? setterMethod = (IMethodSymbol?)AttachedType.GetMembers(setterMethodName).FirstOrDefault();

                    var attachedProperty = new AttachedProperty(Context, this, AttachedType, getterMethod, setterMethod);

                    attachedProperty.GenerateExtensionClassMethods(methods);
                }
            }

            if (!(methods.IsEmpty && staticFields.IsEmpty))
            {
                string extensionsClassName = FrameworkClassName + "Extensions";
                Source extensionsClassSource = GenerateStaticClassFile(usings, NamespaceName, extensionsClassName, methods, staticFields);
                Context.Output.AddSource(null, NamespaceName, extensionsClassName, extensionsClassSource);
            }
        }

        public Source GenerateStaticClassFile(Usings usings, string namespaceName, string className, Source staticMethods, Source? staticFields = null)
        {
            Source fileSource = new Source(Context);

            GenerateFileHeader(fileSource);

            Source usingDeclarations = usings.Generate();
            if (!usingDeclarations.IsEmpty)
            {
                fileSource.AddSource(usingDeclarations);
                fileSource.AddBlankLine();
            }

            fileSource.AddLines(
                $"namespace {namespaceName}",
                "{");

            using (fileSource.Indent())
            {
                fileSource.AddLines(
                    $"public static class {className}",
                    "{");
                using (fileSource.Indent())
                {
                    if (staticFields != null && !staticFields.IsEmpty)
                    {
                        fileSource.AddSource(staticFields);
                        fileSource.AddBlankLine();
                    }

                    fileSource.AddSource(
                        staticMethods);
                }
                fileSource.AddLine(
                    "}");
            }

            fileSource.AddLine(
                "}");

            return fileSource;
        }

        private void GenerateFileHeader(Source fileSource)
        {
            fileSource.AddLine($"// This file is generated from {Name}.cs. Update the source file to change its contents.");
            fileSource.AddBlankLine();
        }

        private string? GetOutputBaseClass(UIFramework uiFramework, Usings? usings = null)
        {
            INamedTypeSymbol? baseInterface = Type.Interfaces.FirstOrDefault();

            if (baseInterface == null)
                return null;
            else
                return uiFramework.OutputTypeName(baseInterface, usings);
        }
    }
}
