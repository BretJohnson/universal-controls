// This file is copied, with modifications, from the Uno project

using SkiaSharp;

namespace UniversalUI.Composition;

partial record struct NonUniformCornerRadius
{
	unsafe internal void GetRadii(SKPoint* radiiStore)
	{
		*(radiiStore++) = new(TopLeft.X, TopLeft.Y);
		*(radiiStore++) = new(TopRight.X, TopRight.Y);
		*(radiiStore++) = new(BottomRight.X, BottomRight.Y);
		*radiiStore = new(BottomLeft.X, BottomLeft.Y);
	}
}
