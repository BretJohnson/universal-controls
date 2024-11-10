using System;

namespace AnywhereControls.Media.Wpf
{
    public static class TransformExtensions
    {
        public static System.Windows.Media.Transform ToWpfTransform(this ITransform transform) =>
            transform switch
            {
                IRotateTransform rotateTransform => ToWpfRotateTransform(rotateTransform),
                IScaleTransform scaleTransform => ToWpfScaleTransform(scaleTransform),
                ITranslateTransform translateTransform => ToWpfTranslateTransform(translateTransform),
                _ => throw new ArgumentException(nameof(transform), $"Unsupported ITransform type {transform.GetType()}")
            };

        public static System.Windows.Media.RotateTransform ToWpfRotateTransform(this IRotateTransform rotateTransform) =>
            new System.Windows.Media.RotateTransform(
                angle: rotateTransform.Angle,
                centerX: rotateTransform.CenterX,
                centerY: rotateTransform.CenterY);

        public static System.Windows.Media.ScaleTransform ToWpfScaleTransform(this IScaleTransform scaleTransform) =>
            new System.Windows.Media.ScaleTransform(
                scaleX: scaleTransform.ScaleX,
                scaleY: scaleTransform.ScaleY,
                centerX: scaleTransform.CenterX,
                centerY: scaleTransform.CenterY);

        public static System.Windows.Media.TranslateTransform ToWpfTranslateTransform(this ITranslateTransform translateTransform) =>
            new System.Windows.Media.TranslateTransform(
                offsetX: translateTransform.X,
                offsetY: translateTransform.Y);

    }
}
