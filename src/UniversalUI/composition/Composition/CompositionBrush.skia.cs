// This file is copied, with modifications, from the Uno project

using SkiaSharp;

namespace UniversalUI.Composition
{
	public partial class CompositionBrush
	{
		internal virtual void UpdatePaint(SKPaint paint, SKRect bounds)
		{
		}

		internal virtual bool CanPaint() => false;

		internal virtual bool RequiresRepaintOnEveryFrame => false;
	}
}
