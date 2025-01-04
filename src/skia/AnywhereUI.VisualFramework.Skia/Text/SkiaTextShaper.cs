using AnywhereUI.VisualFramework.Text;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaTextShaper : ITextShaper
{
    private bool _disposed;

    public SkiaTextShaper(SkiaTypeface skiaTypeface)
    {
        SkiaTypeface = skiaTypeface;
        SKShaper = new SKShaper(SkiaTypeface.SKTypeface);
    }

    public SkiaTypeface SkiaTypeface { get; }

    public SKShaper SKShaper { get; }

    public ITypeface Typeface => SkiaTypeface;

    public ITextShapeResult Shape(string text, float xOffset, float yOffset, IFont font)
    {
        SKShaper.Result result = SKShaper.Shape(text, xOffset, yOffset, ((SkiaFont)font).SKFont);

        return new SkiaTextShapeResult(result);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                SKShaper.Dispose();
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
