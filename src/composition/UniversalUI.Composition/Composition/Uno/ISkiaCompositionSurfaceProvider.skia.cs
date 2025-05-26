#nullable enable

using SkiaSharp;
using UniversalUI.Composition;

namespace Uno.UI.Composition
{
	internal interface ISkiaCompositionSurfaceProvider
	{
		SkiaCompositionSurface? SkiaCompositionSurface { get; }
	}
}
