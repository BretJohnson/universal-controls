// This file is generated from IVisualState.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI
{
    public static class VisualStateExtensions
    {
        public static T Setters<T>(this T visualState, params ISetter[] value) where T : IVisualState
        {
            visualState.Setters.Set(value);
            return visualState;
        }
    }
}
