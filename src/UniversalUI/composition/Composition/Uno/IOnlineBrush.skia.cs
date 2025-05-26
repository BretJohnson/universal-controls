// This file is copied, with modifications, from the Uno project

#nullable enable

using UniversalUI.Composition;
using SkiaSharp;

namespace Uno.UI.Composition
{
	internal interface IOnlineBrush
	{
		internal bool IsOnline { get; }
		internal void Paint(in Visual.PaintingSession session, SKRect bounds = new());
	}
}
