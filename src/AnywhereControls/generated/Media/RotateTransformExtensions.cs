// This file is generated from IRotateTransform.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Media
{
    public static class RotateTransformExtensions
    {
        public static T Angle<T>(this T rotateTransform, double value) where T : IRotateTransform
        {
            rotateTransform.Angle = value;
            return rotateTransform;
        }
        
        public static T CenterX<T>(this T rotateTransform, double value) where T : IRotateTransform
        {
            rotateTransform.CenterX = value;
            return rotateTransform;
        }
        
        public static T CenterY<T>(this T rotateTransform, double value) where T : IRotateTransform
        {
            rotateTransform.CenterY = value;
            return rotateTransform;
        }
    }
}
