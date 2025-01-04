using AnywhereUI.VisualFramework.Text;
using SkiaSharp;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public interface ISkiaFont : IFont
{
    public SKFont SKFont { get; }
}
