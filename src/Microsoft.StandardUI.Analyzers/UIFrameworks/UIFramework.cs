using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Globalization;
using Microsoft.CodeAnalysis;

namespace Microsoft.StandardUI.SourceGenerator.UIFrameworks
{
    public abstract class UIFramework
    {
        public Context Context { get; }

        protected UIFramework(Context context)
        {
            Context = context;
        }

        public abstract string Name { get; }
        public virtual string NamespaceSuffix => Name;
        public virtual string ProjectBaseDirectory => $"Microsoft.StandardUI.{Name}";
        public string RootNamespace => $"Microsoft.StandardUI.{NamespaceSuffix}";
        public abstract string FrameworkTypeForUIElementAttachedTarget { get; }
        public abstract string NativeUIElementType { get; }
        public virtual TypeName BuiltInUIElementBaseClassType => new(RootNamespace, "BuiltInUIElement");
        public virtual TypeName BuiltInUIObjectBaseClassType => new(RootNamespace, "StandardUIObject");
        public virtual TypeName StandardControlBaseClassType => new(RootNamespace, Name + "StandardControl");

        public virtual string PropertyDescriptorName(Property property) => property.Name + "Property";
        public virtual string PropertyDescriptorName(AttachedProperty property) => property.Name + "Property";

        public virtual void AddTypeAliasUsingIfNeeded(Usings usings, string destinationtypeFullName) { }

        public virtual void GenerateAttributes(Interface intface, ClassSource classSource) { }
        public abstract void GenerateProperty(Property property, ClassSource classSource);
        public abstract void GenerateAttachedProperty(AttachedProperty attachedProperty, ClassSource mainClassSource, ClassSource attachedClassSource);

        public virtual void GeneratePanelMethods(Source methods) { }

        public virtual void GenerateDrawableObjectMethods(Interface intface, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine(
                $"public override void Draw(IDrawingContext drawingContext) => drawingContext.Draw{intface.FrameworkClassName}(this);");
        }

        public virtual void GenerateIUIElementMethods(ClassSource classSource) { }

        public string ToFrameworkNamespaceName(INamespaceSymbol namespc)
        {
            // For controls outside the StandardUI namespace - user provided, not built in -
            // just keep with a the original namespace, not using a child namespace per platform
            string namespaceName = Utils.GetNamespaceFullName(namespc);
            if (!namespaceName.StartsWith(Utils.StandardUIRootNamespace))
                return $"{namespaceName}.{NamespaceSuffix}";

            // Map e.g. Microsoft.StandardUI.Media source namespace => Microsoft.StandardUI.Wpf.Media destination namespace
            // If the source namespace is just Microsoft.StandardUI, don't change anything here
            string? childNamespaceName = Utils.GetChildNamespaceName(namespaceName);
            if (childNamespaceName == null)
                return RootNamespace;
            else return RootNamespace + "." + childNamespaceName;
        }

        public string OutputTypeName(ITypeSymbol type, Usings? usings = null)
        {
            string typeName = type.Name;

            string destinationTypeName;
            if (Utils.IsThisType(type, KnownTypes.IUIObject))
            {
                destinationTypeName = BuiltInUIObjectBaseClassType.Name;
                usings?.AddNamespace(BuiltInUIObjectBaseClassType);
            }
            else if (Utils.IsThisType(type, KnownTypes.IUIElement))
            {
                destinationTypeName = BuiltInUIElementBaseClassType.Name;
                usings?.AddNamespace(BuiltInUIElementBaseClassType);
            }
            else if (Utils.IsThisType(type, KnownTypes.IStandardControl))
            {
                destinationTypeName = StandardControlBaseClassType.Name;
                usings?.AddNamespace(StandardControlBaseClassType);
            }
            else if (Utils.IsUICollectionType(Context, type, out ITypeSymbol elementType))
            {
                if (Utils.IsThisType(elementType, KnownTypes.IUIElement))
                    destinationTypeName = UIElementCollectionOutputTypeName(elementType);
                else if (Utils.IsSubtypeOf(elementType, KnownTypes.IUIElement))
                    destinationTypeName = UIElementSubtypeCollectionOutputTypeName(elementType);
                else destinationTypeName = $"UICollection<{elementType.Name}>";
            }
            else if (Utils.IsUIModelInterfaceType(type))
                destinationTypeName = typeName.Substring(1);
            else if (IsWrappedType(type))
                destinationTypeName = GetTypeNameWrapIfNeeded(type);
            else destinationTypeName = Utils.ToTypeName(type);

            return Utils.AddNullableSuffixIfNeeded(destinationTypeName, type.NullableAnnotation);
        }

        public virtual string UIElementCollectionOutputTypeName(ITypeSymbol elementType) => $"UIElementCollection<{elementType}>";
        public virtual string UIElementSubtypeCollectionOutputTypeName(ITypeSymbol elementType) => $"UIElementCollection<{elementType}>";

        public string PropertyOutputTypeName(PropertyBase property) => OutputTypeName(property.Type);

        public string PropertyFieldName(PropertyBase property)
        {
            return "_" + Utils.PascalCaseToCamelCase(property.Name);
        }

        public virtual string AttachedTargetOutputTypeName(AttachedProperty attachedProperty)
        {
            return Utils.IsThisType(attachedProperty.TargetType, KnownTypes.IUIElement) ?
                FrameworkTypeForUIElementAttachedTarget :
                OutputTypeName(attachedProperty.TargetType);
        }

        public virtual string WrapperSuffix => Name;

        public virtual bool IsWrappedType(ITypeSymbol type) => false;

        public string GetTypeNameWrapIfNeeded(ITypeSymbol type)
        {
            if (IsWrappedType(type))
                return type.Name + WrapperSuffix;
            else return type.Name;
        }

        public string DefaultValue(PropertyBase property)
        {
            ITypeSymbol propertyType = property.Type;
            string typeFullName = Utils.GetTypeFullName(propertyType);

            if (property.SpecifiedDefaultValue != null)
            {
                TypedConstant specifiedDefaultValue = property.SpecifiedDefaultValue.Value;

                if (specifiedDefaultValue.IsNull)
                {
                    return "null";
                }

                var kind = specifiedDefaultValue.Kind;
                object value = specifiedDefaultValue.Value!;

                if (kind == TypedConstantKind.Primitive)
                {
                    if (value is string stringArgumentValue)
                    {
                        if (typeFullName == "Microsoft.StandardUI.Point" && stringArgumentValue == "0.5,0.5")
                            return $"{OutputTypeName(propertyType)}.CenterDefault";
                        else if (stringArgumentValue == "")
                            return "\"\"";
                        else new UserViewableException($"Unknown string literal based default value: {stringArgumentValue}");
                    }
                    else if (value is double doubleArgumentValue)
                    {
                        if (double.IsPositiveInfinity(doubleArgumentValue))
                            return "double.PositiveInfinity";
                        else if (double.IsNegativeInfinity(doubleArgumentValue))
                            return "double.NegativeInfinity";
                        else if (double.IsNaN(doubleArgumentValue))
                            return "double.NaN";
                        else if (doubleArgumentValue - Math.Truncate(doubleArgumentValue) == 0)
                            return doubleArgumentValue.ToString("F1", CultureInfo.InvariantCulture);
                        else return doubleArgumentValue.ToString(CultureInfo.InvariantCulture);
                    }
                    else if (value is int intArgumentValue)
                    {
                        return intArgumentValue.ToString(CultureInfo.InvariantCulture);
                    }
                    else if (value is bool boolArgumentValue)
                    {
                        return boolArgumentValue ? "true" : "false";
                    }

                    throw new UserViewableException($"{property.FullPropertyName} default value {value.ToString()} not yet supported");
                }
                else if (kind == TypedConstantKind.Enum)
                {
                    object enumValue = value;
                    ITypeSymbol type = specifiedDefaultValue.Type!;
                    ImmutableArray<ISymbol> enumMembers = type.GetMembers();

                    // For enums, use the fully qualified type name by default, to avoid conflicts.
                    // But for known Standard UI types, use the short type name in most cases to be
                    // more concise. The only exception is standard UI types that have known conflicts
                    // with UI framework type names.
                    string fullTypeName = Utils.GetTypeFullName(type);
                    string typeName = fullTypeName;
                    if (fullTypeName.StartsWith("Microsoft.StandardUI"))
                    {
                        if (fullTypeName != "Microsoft.StandardUI.TextWrapping")
                            typeName = type.Name;
                    }

                    foreach (IFieldSymbol enumFieldMember in enumMembers)
                    {
                        object? enumFieldValue = enumFieldMember.ConstantValue;
                        if (enumFieldValue != null && enumFieldValue.Equals(value))
                            return $"{typeName}.{enumFieldMember.Name}";
                    }

                    throw new UserViewableException($"No symbol found in enum {type.Name} for value {enumValue}");
                }

                // TODO: add explicit checks for different expression types
                return value.ToString();
                // throw new UserViewableException($"Default value type {argument} not yet supported");
            }

            if (typeFullName == "System.Collections.Generic.IEnumerable")
                return "null";

            if (Utils.IsUICollectionType(Context, propertyType))
                return "null";

            if (typeFullName == "Microsoft.StandardUI.Color" ||
                typeFullName == "Microsoft.StandardUI.Point" ||
                typeFullName == "Microsoft.StandardUI.Points" ||
                typeFullName == "Microsoft.StandardUI.Size" ||
                typeFullName == "Microsoft.StandardUI.Thickness" ||
                typeFullName == "Microsoft.StandardUI.CornerRadius" ||
                typeFullName == "Microsoft.StandardUI.Text.FontWeight" ||
                typeFullName == "Microsoft.StandardUI.GridLength")
            {
                return $"{GetTypeNameWrapIfNeeded(propertyType)}.Default";
            }

            if (typeFullName == "Microsoft.StandardUI.Media.FontFamily")
                return FontFamilyDefaultValue;

            // TODO: Implement this
#if false
            else if (propertyType is IArrayTypeSymbol arrayTypeSymbol)
            {
                return
                    InvocationExpression(
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName("Array"),
                            GenericName(
                                    Identifier("Empty"))
                                .WithTypeArgumentList(
                                    TypeArgumentList(
                                        SingletonSeparatedList<TypeSyntax>(arrayType.ElementType)))));
            }
#endif

            throw UserVisibleErrors.PropertyHasNoDefaultValue(property.Symbol, property.FullPropertyName);
        }

        protected virtual string? PropertyTypeDefaultValue(INamedTypeSymbol propertyType)
        {
            string typeFullName = Utils.GetTypeFullName(propertyType);

            if (propertyType is INamedTypeSymbol namedTypeSymbol &&
                namedTypeSymbol.Name is string typeName &&
                (typeName == "Microsoft.StandardUI.Color" ||
                typeName == "Microsoft.StandardUI.Point" ||
                typeName == "Microsoft.StandardUI.Points" ||
                typeName == "Microsoft.StandardUI.Size" ||
                typeName == "Microsoft.StandardUI.Thickness" ||
                typeName == "Microsoft.StandardUI.CornerRadius" ||
                typeName == "Microsoft.StandardUI.FontWeight"))
            {
                return $"{GetTypeNameWrapIfNeeded(propertyType)}.Default";
            }

            return null;
        }

        protected abstract string FontFamilyDefaultValue { get; }

        public virtual void GenerateBuiltInIUIElementPartialClasses() { }

        public virtual void GenerateStandardPanelLayoutMethods(string layoutManagerTypeName, Source methods)
        {
            methods.AddBlankLineIfNonempty();
            methods.AddLine($"protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.MeasureOverride(this, widthConstraint, heightConstraint);");
            }

            methods.AddBlankLine();
            methods.AddLine($"protected override Size ArrangeOverride(Rect bounds) =>");
            using (methods.Indent())
            {
                methods.AddLine(
                    $"{layoutManagerTypeName}.Instance.ArrangeOverride(this, bounds.Size);");
            }
        }
    }
}
