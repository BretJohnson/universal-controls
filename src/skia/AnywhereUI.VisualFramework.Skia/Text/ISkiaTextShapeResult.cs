using AnywhereUI.VisualFramework.Text;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public interface ISkiaTextShapeResult : ITextShapeResult
{
    public SKShaper.Result SKResult { get; }
}
