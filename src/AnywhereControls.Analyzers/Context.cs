using Microsoft.CodeAnalysis;

namespace AnywhereControls.SourceGenerator
{
    public class Context
    {
        public int IndentSize { get; } = 4;
        public Compilation Compilation { get; }
        public Output Output { get; }

        public INamedTypeSymbol VoidType { get; }

        public Context(Compilation compilation, Output outputLocation)
        {
            Compilation = compilation;
            Output = outputLocation;
            VoidType = compilation.GetSpecialType(SpecialType.System_Void);
        }
    }
}
