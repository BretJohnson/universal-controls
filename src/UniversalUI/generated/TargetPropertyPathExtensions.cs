// This file is generated from ITargetPropertyPath.cs. Update the source file to change its contents.

namespace UniversalUI
{
    public static class TargetPropertyPathExtensions
    {
        public static T Property<T>(this T targetPropertyPath, IPropertyPath value) where T : ITargetPropertyPath
        {
            targetPropertyPath.Property = value;
            return targetPropertyPath;
        }
        
        public static T Target<T>(this T targetPropertyPath, object value) where T : ITargetPropertyPath
        {
            targetPropertyPath.Target = value;
            return targetPropertyPath;
        }
    }
}
