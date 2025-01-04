using System;
using System.Runtime.InteropServices;
using AnywhereUI.VisualFramework.Text;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaTextShapeResult : ITextShapeResult
{
    public SkiaTextShapeResult(SKShaper.Result skResult)
    {
        SKResult = skResult;
    }

    public SKShaper.Result SKResult { get; }

    public ReadOnlySpan<uint> Codepoints => SKResult.Codepoints;

    public ReadOnlySpan<uint> Clusters => SKResult.Clusters;

    public ReadOnlySpan<PointF> Points => MemoryMarshal.Cast<SKPoint, PointF>(SKResult.Points);

    public float Width => SKResult.Width;
}
