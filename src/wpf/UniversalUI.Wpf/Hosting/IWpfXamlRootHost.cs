// This file is copied, with modifications, from the Uno project.

using UniversalUI.Hosting;
using WpfCanvas = System.Windows.Controls.Canvas;

namespace UniversalUI.Wpf.Hosting;

internal interface IWpfUIRootHost : IUIRootHost
{
	WpfCanvas? NativeOverlayLayer { get; }

	bool IgnorePixelScaling { get; }

	RenderSurfaceType? RenderSurfaceType { get; }
}
