using System;

namespace UniversalUI
{
    public class UnintializedHostFramework : IHostFramework
    {
        public static UnintializedHostFramework Instance = new UnintializedHostFramework();

        public IVisualFramework VisualFramework => throw new InvalidOperationException("The Standard UI host framework hasn't been initialized");

        public IAnywhereControlsUIFactory Factory => throw new InvalidOperationException("The Standard UI host framework hasn't been initialized");
    }
}
