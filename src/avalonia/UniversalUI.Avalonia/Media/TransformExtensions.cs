using UniversalUI.Media;

namespace AnywhereControlsAvalonia.Media;

public static class TransformExtensions
{
    public static Avalonia.Media.Transform ToAvaloniaTransform(this ITransform transform) =>
        transform switch
        {
            IRotateTransform rotateTransform => ToWpfRotateTransform(rotateTransform),
            IScaleTransform scaleTransform => ToWpfScaleTransform(scaleTransform),
            ITranslateTransform translateTransform => ToWpfTranslateTransform(translateTransform),
            _ => throw new ArgumentException(nameof(transform), $"Unsupported ITransform type {transform.GetType()}")
        };

    public static Avalonia.Media.RotateTransform ToWpfRotateTransform(this IRotateTransform rotateTransform) =>
        new Avalonia.Media.RotateTransform(
            angle: rotateTransform.Angle,
            centerX: rotateTransform.CenterX,
            centerY: rotateTransform.CenterY);

    public static Avalonia.Media.ScaleTransform ToWpfScaleTransform(this IScaleTransform scaleTransform) =>
        new Avalonia.Media.ScaleTransform(
            scaleX: scaleTransform.ScaleX,
            scaleY: scaleTransform.ScaleY);

    public static Avalonia.Media.TranslateTransform ToWpfTranslateTransform(this ITranslateTransform translateTransform) =>
        new Avalonia.Media.TranslateTransform(
            x: translateTransform.X,
            y: translateTransform.Y);

}
