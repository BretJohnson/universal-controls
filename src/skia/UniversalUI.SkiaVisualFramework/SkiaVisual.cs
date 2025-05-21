using SkiaSharp;

namespace UniversalUI.SkiaVisualFramework
{
    public class SkiaVisual : IVisual
    {
        public SKPicture SKPicture { get; }

        public SkiaVisual(SKPicture sKPicture)
        {
            SKPicture = sKPicture;
        }

        public object NativeVisual => SKPicture;
    }
}
