using AnywhereUI.VisualFramework.Text;
using SkiaSharp;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaFont : IFont
{
    private bool _disposed;

    public SkiaFont(SkiaTypeface skiaTypeface, double size)
    {
        SkiaTypeface = skiaTypeface;
        Size = size;

        SKFont = new SKFont(skiaTypeface.SKTypeface, (float)size);
    }

    public SkiaTypeface SkiaTypeface { get; }

    public SKFont SKFont { get; }

    public double Size { get; }

    public ITypeface Typeface => SkiaTypeface;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                SKFont.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        System.GC.SuppressFinalize(this);
    }
}
