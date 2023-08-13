// This file is generated from IScaleTransform.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Media
{
    public static class ScaleTransformExtensions
    {
        public static T CenterX<T>(this T scaleTransform, double value) where T : IScaleTransform
        {
            scaleTransform.CenterX = value;
            return scaleTransform;
        }
        
        public static T CenterY<T>(this T scaleTransform, double value) where T : IScaleTransform
        {
            scaleTransform.CenterY = value;
            return scaleTransform;
        }
        
        public static T ScaleX<T>(this T scaleTransform, double value) where T : IScaleTransform
        {
            scaleTransform.ScaleX = value;
            return scaleTransform;
        }
        
        public static T ScaleY<T>(this T scaleTransform, double value) where T : IScaleTransform
        {
            scaleTransform.ScaleY = value;
            return scaleTransform;
        }
    }
}
