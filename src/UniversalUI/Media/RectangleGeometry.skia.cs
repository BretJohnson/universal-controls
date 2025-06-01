// This file is copied, with modifications, from the Uno project

using System.Numerics;
using SkiaSharp;
using UniversalUI.Composition;

namespace UniversalUI.Media;

partial class RectangleGeometry
{
	internal override SKPath GetSKPath() =>
		CompositionGeometry.BuildRectangleGeometry(offset: new Vector2((float)Rect.X, (float)Rect.Y), size: new Vector2((float)Rect.Width, (float)Rect.Height));
}
