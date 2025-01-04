using System;
using System.Runtime.InteropServices;
using AnywhereUI.VisualFramework.Text;
using SkiaSharp;
using SkiaSharp.HarfBuzz;

namespace AnywhereUI.VisualFramwork.Skia.Text;

public class SkiaTextShapeResult : ISkiaTextShapeResult
{
    private readonly SKShaper.Result _skResult;

    public SkiaTextShapeResult(SKShaper.Result skResult)
    {
        _skResult = skResult;
    }

    ReadOnlySpan<uint> ITextShapeResult.Codepoints => _skResult.Codepoints;

    ReadOnlySpan<uint> ITextShapeResult.Clusters => _skResult.Clusters;

    ReadOnlySpan<PointF> ITextShapeResult.Points => MemoryMarshal.Cast<SKPoint, PointF>(_skResult.Points);

    float ITextShapeResult.Width => _skResult.Width;

    SKShaper.Result ISkiaTextShapeResult.SKResult => _skResult;
}
