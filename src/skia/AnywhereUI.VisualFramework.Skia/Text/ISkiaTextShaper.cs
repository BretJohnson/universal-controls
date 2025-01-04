using AnywhereUI.VisualFramework.Text;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public interface ISkiaTextShaper : ITextShaper
{
    public SKShaper SKShaper { get; }
}
