using AnywhereUI.Media;
using AnywhereUI.Text;
using AnywhereUI.VisualFramework.Text;
using SkiaSharp;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaTypeface : ITypeface
{
    private bool _disposed;

    public SkiaTypeface(SKTypeface skTypeface)
    {
        SKTypeface = skTypeface;
    }

    public SKTypeface SKTypeface { get; }

    public FontFamily FontFamily => new FontFamily(SKTypeface.FamilyName);

    public FontStyle Style => throw new System.NotImplementedException();

    public FontWeight Weight => throw new System.NotImplementedException();

    public FontStretch Stretch => throw new System.NotImplementedException();

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                SKTypeface.Dispose();
            }
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        System.GC.SuppressFinalize(this);
    }
}
