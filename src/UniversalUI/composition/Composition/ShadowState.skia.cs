// This file is copied, with modifications, from the Uno project

using System;
using UniversalUI.Composition;
using SkiaSharp;
using UniversalUI;

namespace Uno.UI.Composition.Composition;

/// <summary>
/// Captures the state of drop shadow for a visual.
/// </summary>
internal record ShadowState(float Dx, float Dy, float SigmaX, float SigmaY, Color Color)
{
	private SKPaint? _shadowOnlyPaint;

	public SKPaint ShadowOnlyPaint =>
		_shadowOnlyPaint ??= new SKPaint()
		{
			// Equivalent (I think) to SKImageFilter.CreateDropShadow(Dx, Dy, SigmaX, SigmaY, Color.ToSKColor()) but much much faster
			// Writing our own shader that does the same (basically takes the alpha value of the given pixel
			// adjust by (Dx, Dy) and multiplies it by ShadowState.Color and "modulates" it with the original
			// pixel) did not improve the numbers one bit.
			ImageFilter = SKImageFilter.CreateOffset(Dx, Dy, SKImageFilter.CreateCompose(SKImageFilter.CreateBlur(SigmaX, SigmaY), SKImageFilter.CreateColorFilter(SKColorFilter.CreateBlendMode(Color.ToSKColor(), SKBlendMode.Modulate))))
		};
}
