// This file is generated from IVisualStateGroup.cs. Update the source file to change its contents.

namespace UniversalUI
{
    public static class VisualStateGroupExtensions
    {
        public static T States<T>(this T visualStateGroup, params IVisualState[] value) where T : IVisualStateGroup
        {
            visualStateGroup.States.Set(value);
            return visualStateGroup;
        }
    }
}
