// This file is copied, with modifications, from the Uno project

using SkiaSharp;
using UniversalUI.Composition;

namespace Uno.UI.Composition
{
	internal interface ISkiaCompositionSurfaceProvider
	{
		SkiaCompositionSurface? SkiaCompositionSurface { get; }
	}
}
