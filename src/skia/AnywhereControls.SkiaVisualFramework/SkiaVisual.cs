using SkiaSharp;

namespace Microsoft.StandardUI.SkiaVisualFramework
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
