// This file is copied, with modifications, from the Uno project

#nullable disable

using SkiaSharp;

namespace UniversalUI.Composition;

internal partial class CompositionBrushWrapper : CompositionBrush
{
	private CompositionBrush _wrappedBrush;

	internal CompositionBrush WrappedBrush
	{
		get => _wrappedBrush;
		set => SetProperty(ref _wrappedBrush, value);
	}

	internal CompositionBrushWrapper(CompositionBrush wrappedBrush, Compositor compositor) : base(compositor)
	{
		WrappedBrush = wrappedBrush;
	}

	internal override void UpdatePaint(SKPaint paint, SKRect bounds)
	{
		WrappedBrush?.UpdatePaint(paint, bounds);
	}

	internal override bool CanPaint() => WrappedBrush?.CanPaint() ?? false;
}
