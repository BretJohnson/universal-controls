// This file is copied, with modifications, from the Uno project.

using System;
using System.Windows.Media;
using UniversalUI.Rendering;

namespace UniversalUI.Wpf.Rendering;

internal interface IWpfRenderer : IRenderer, IDisposable
{
	bool TryInitialize();

	void Render(DrawingContext drawingContext);
}
