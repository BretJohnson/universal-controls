// This file is copied, with modifications, from the Uno project

#nullable disable

using SkiaSharp;
using Windows.Foundation;

namespace UniversalUI.Composition;

partial class InsetClip
{
	private (Rect? bounds, SKPath path)? _clipPath;

	private protected override Rect? GetBoundsCore(Visual visual)
	{
		return new Rect(
			x: LeftInset,
			y: TopInset,
			width: visual.Size.X - LeftInset - RightInset,
			height: visual.Size.Y - TopInset - BottomInset);
	}

	internal override SKPath GetClipPath(Visual visual)
	{
		var bounds = GetBounds(visual).Value;
		if (_clipPath is null || _clipPath.Value.bounds != bounds)
		{
			var path = new SKPath();
			var rect = bounds.ToSKRect();
			path.AddRect(rect);
			_clipPath = (bounds, path);
		}
		return _clipPath.Value.path;
	}
}
