using System;

namespace AnywhereUI.VisualFramework.Text;

public interface ITextShapeResult
{
    public ReadOnlySpan<uint> Codepoints { get; }

    public ReadOnlySpan<uint> Clusters { get; }

    public ReadOnlySpan<PointF> Points { get; }

    public float Width { get; }
}
