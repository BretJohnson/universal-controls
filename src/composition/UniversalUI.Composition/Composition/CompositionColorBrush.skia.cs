using SkiaSharp;


namespace UniversalUI.Composition
{
	public partial class CompositionColorBrush
	{
		internal override void UpdatePaint(SKPaint paint, SKRect bounds)
		{
			paint.Color = Color.ToSKColor();
		}

		internal override bool CanPaint() => Color != Colors.Transparent;
	}
}
