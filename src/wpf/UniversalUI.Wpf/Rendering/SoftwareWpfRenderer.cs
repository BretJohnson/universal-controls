// This file is copied, with modifications, from the Uno project.

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SkiaSharp;
using Visibility = System.Windows.Visibility;
using WpfControl = global::System.Windows.Controls.Control;
using UniversalUI.Wpf.Hosting;
using UniversalUI.Helpers;
using UniversalUI.Logging;

namespace UniversalUI.Wpf.Rendering;

internal class SoftwareWpfRenderer : IWpfRenderer
{
	private readonly WpfControl _hostControl;
	private readonly IWpfUIRootHost _host;
	private WriteableBitmap? _bitmap;

	public SoftwareWpfRenderer(IWpfUIRootHost host)
	{
		_hostControl = host as WpfControl ?? throw new InvalidOperationException("Host should be a WPF control");
		_host = host;
	}

	public SKColor BackgroundColor { get; set; } = SKColors.White;

	public bool TryInitialize() => true;

	public void Dispose() { }

	public void Render(DrawingContext drawingContext)
	{
		if (_hostControl.ActualWidth == 0
			|| _hostControl.ActualHeight == 0
			|| double.IsNaN(_hostControl.ActualWidth)
			|| double.IsNaN(_hostControl.ActualHeight)
			|| double.IsInfinity(_hostControl.ActualWidth)
			|| double.IsInfinity(_hostControl.ActualHeight)
			|| _hostControl.Visibility != Visibility.Visible)
		{
			return;
		}

		int width, height;

		var dpi = _host.RasterizationScale;
		double dpiScaleX = dpi;
		double dpiScaleY = dpi;
		if (_host.IgnorePixelScaling)
		{
			width = (int)_hostControl.ActualWidth;
			height = (int)_hostControl.ActualHeight;
		}
		else
		{
			var matrix = PresentationSource.FromVisual(_hostControl).CompositionTarget.TransformToDevice;
			dpiScaleX = matrix.M11;
			dpiScaleY = matrix.M22;
			width = (int)(_hostControl.ActualWidth * dpiScaleX);
			height = (int)(_hostControl.ActualHeight * dpiScaleY);
		}

		var info = new SKImageInfo(width, height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

		// reset the bitmap if the size has changed
		if (_bitmap == null || info.Width != _bitmap.PixelWidth || info.Height != _bitmap.PixelHeight)
		{
			_bitmap = new WriteableBitmap(width, height, 96 * dpiScaleX, 96 * dpiScaleY, PixelFormats.Pbgra32, null);
		}

		// draw on the bitmap
		_bitmap.Lock();
		using (var surface = SKSurface.Create(info, _bitmap.BackBuffer, _bitmap.BackBufferStride))
		{
			var canvas = surface.Canvas;
			canvas.Clear(BackgroundColor);
			canvas.SetMatrix(SKMatrix.CreateScale((float)dpiScaleX, (float)dpiScaleY));
			if (_host.RootElementVisual is { } rootVisual)
			{
				var isSoftwareRenderer = rootVisual.Compositor.IsSoftwareRenderer;
				try
				{
					rootVisual.Compositor.IsSoftwareRenderer = true;

					var negativePath = SkiaRenderHelper.RenderRootVisualAndReturnNegativePath(width, height, rootVisual, surface.Canvas);

					if (_host.NativeOverlayLayer is { } nativeLayer)
					{
						nativeLayer.Clip ??= new PathGeometry();
						((PathGeometry)nativeLayer!.Clip).Figures = PathFigureCollection.Parse(negativePath.ToSvgPathData());
					}
					else
					{
						if (this.Log().IsEnabled(LogLevel.Error))
						{
							this.Log().Error($"Airspace clipping failed because ${nameof(_host.NativeOverlayLayer)} is null");
						}
					}
				}
				finally
				{
					rootVisual.Compositor.IsSoftwareRenderer = isSoftwareRenderer;
				}
			}
		}

		// draw the bitmap to the screen
		_bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
		_bitmap.Unlock();
		drawingContext.DrawImage(_bitmap, new System.Windows.Rect(0, 0, _hostControl.ActualWidth, _hostControl.ActualHeight));
	}
}
