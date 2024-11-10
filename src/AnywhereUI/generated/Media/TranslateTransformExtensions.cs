// This file is generated from ITranslateTransform.cs. Update the source file to change its contents.

namespace AnywhereControls.Media
{
    public static class TranslateTransformExtensions
    {
        public static T X<T>(this T translateTransform, double value) where T : ITranslateTransform
        {
            translateTransform.X = value;
            return translateTransform;
        }
        
        public static T Y<T>(this T translateTransform, double value) where T : ITranslateTransform
        {
            translateTransform.Y = value;
            return translateTransform;
        }
    }
}
