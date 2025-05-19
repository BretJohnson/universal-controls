// This file is generated from IStackBase.cs. Update the source file to change its contents.

namespace AnywhereUI.Controls
{
    public static class StackBaseExtensions
    {
        public static T Spacing<T>(this T stackBase, double value) where T : IStackBase
        {
            stackBase.Spacing = value;
            return stackBase;
        }
    }
}
