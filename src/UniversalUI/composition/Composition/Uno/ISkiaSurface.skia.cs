// This file is copied, with modifications, from the Uno project

using UniversalUI.Composition;
using SkiaSharp;

namespace Uno.UI.Composition
{
	internal interface ISkiaSurface
	{
		internal SKSurface? Surface { get; }
		internal void UpdateSurface(bool recreateSurface = false);
		internal void UpdateSurface(in Visual.PaintingSession session);
	}
}
