// This file is generated from ISetter.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI
{
    public static class SetterExtensions
    {
        public static T Property<T>(this T setter, IUIProperty? value) where T : ISetter
        {
            setter.Property = value;
            return setter;
        }
        
        public static T Target<T>(this T setter, ITargetPropertyPath value) where T : ISetter
        {
            setter.Target = value;
            return setter;
        }
        
        public static T Value<T>(this T setter, object value) where T : ISetter
        {
            setter.Value = value;
            return setter;
        }
    }
}
