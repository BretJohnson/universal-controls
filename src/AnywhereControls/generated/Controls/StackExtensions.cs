// This file is generated from IStack.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Controls
{
    public static class StackExtensions
    {
        public static T Orientation<T>(this T stack, Orientation value) where T : IStack
        {
            stack.Orientation = value;
            return stack;
        }
    }
}
