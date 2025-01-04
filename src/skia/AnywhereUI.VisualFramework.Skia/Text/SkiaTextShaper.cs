using AnywhereUI.VisualFramework.Text;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaTextShaper : SKShaper, ISkiaTextShaper
{
    public SkiaTextShaper(SkiaTypeface skiaTypeface) :
        base(skiaTypeface.SKTypeface)
    {
        SkiaTypeface = skiaTypeface;
    }

    public SkiaTypeface SkiaTypeface { get; }

    ITypeface ITextShaper.Typeface => SkiaTypeface;

    ITextShapeResult ITextShaper.Shape(string text, float xOffset, float yOffset, IFont font)
    {
        Result result = Shape(text, xOffset, yOffset, (SkiaFont)font);
        return new SkiaTextShapeResult(result);
    }

    SKShaper ISkiaTextShaper.SKShaper => this;
}
