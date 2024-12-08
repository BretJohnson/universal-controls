using System.Globalization;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace AnywhereUI.SourceGenerator
{
    public static class UserVisibleErrors
    {
        public static UserViewableException CouldNotIdentifyUIFramework() =>
            CreateError(1, message: "No reference to AnywhereUI.<host-framework> assembly found in project");

        public static UserViewableException AttachedTypeMethodMustStartWithGetOrSet(string className, string methodName) =>
            CreateError(2, message: $"Attached type method '{className}.{methodName}' doesn't start with Get or Set");

        public static UserViewableException StandardUIInterfaceMustStartWithI(INamedTypeSymbol interfaceType) =>
            CreateError(3, $"StandardUI interface '{interfaceType.Name}' must start with 'I'", interfaceType);

        public static UserViewableException StandardUIMissingPurposeAttribute(INamedTypeSymbol interfaceType) =>
            CreateError(4, message: $"StandardUI interface '{interfaceType.Name}' missing attribute defining its purpose", interfaceType);

        public static UserViewableException NoLayoutManagerClassFound(string layoutManagerName, string interfaceName) =>
            CreateError(5, message: $"No class '{layoutManagerName}' found for StandardPanel interface '{interfaceName}'");

        public static UserViewableException NoAnywhereControlImplementationClassFound(ISymbol symbol, string anywhereControlImplementationName, string interfaceName) =>
            CreateError(5, message: $"No implementation class '{anywhereControlImplementationName}' found for AnywhereControl interface '{interfaceName}'",
                locationSymbol: symbol);

        public static UserViewableException PropertyHasNoDefaultValue(ISymbol symbol, string fullPropertyName) =>
            CreateError(6, message: $"Property {fullPropertyName} has no [DefaultValue] attribute nor hardcoded default",
                locationSymbol: symbol);

        public static UserViewableException AttributeShouldHaveSingleArgument(ISymbol symbol, string attributeName) =>
            CreateError(7, message: $"{symbol.Name} should have a single argument for the [{attributeName}] attribute",
                locationSymbol: symbol);

        public static UserViewableException AttributeShouldHaveAStringArgument(ISymbol symbol, string attributeName) =>
            CreateError(8, message: $"{symbol.Name} should have a string value for the [{attributeName}] attribute",
                locationSymbol: symbol);

        public static UserViewableException ControlLibraryNameInvalid(INamedTypeSymbol libraryClass) =>
            CreateError(9, message: $"The [ControlLibrary] class name should end with the suffix 'ControlLibrary'",
                locationSymbol: libraryClass);

        public static UserViewableException MissingControlLibraryClass() =>
            CreateError(10, message: $"No [ControlLibrary] class found");

        public static string InternalErrorId = ErrorIdFromInt(99);

        public static Location? GetLocation(ISymbol symbol)
        {
            SyntaxReference? syntaxReference = symbol.DeclaringSyntaxReferences.FirstOrDefault();
            return GetLocation(syntaxReference);
        }

        public static Location? GetLocation(SyntaxReference? syntaxReference)
        {
            if (syntaxReference == null)
                return null;

            return Location.Create(syntaxReference.SyntaxTree, syntaxReference.Span);
        }

        public static string ErrorIdFromInt(int id) => "AC" + id.ToString("0000", CultureInfo.InvariantCulture);

        public static UserViewableException CreateError(int id, string message, Location? location = null) =>
            new UserViewableException(ErrorIdFromInt(id), message, location);

        public static UserViewableException CreateError(int id, string message, ISymbol locationSymbol) =>
            CreateError(id, message, GetLocation(locationSymbol));
    }
}
