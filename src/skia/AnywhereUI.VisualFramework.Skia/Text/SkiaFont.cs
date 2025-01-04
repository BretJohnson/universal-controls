using AnywhereUI.VisualFramework.Text;
using SkiaSharp;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaFont : SKFont, ISkiaFont
{
    public SkiaFont(SkiaTypeface skiaTypeface, double size) :
        base(skiaTypeface.SKTypeface, (float)size)
    {
        SkiaTypeface = skiaTypeface;
    }

    public SkiaTypeface SkiaTypeface { get; }

    ITypeface IFont.Typeface => SkiaTypeface;

    double IFont.Size => (float) Size;

    SKFont ISkiaFont.SKFont => this;
}
