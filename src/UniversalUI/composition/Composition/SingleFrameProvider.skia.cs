// This file is copied, with modifications, from the Uno project

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using SkiaSharp;
using UniversalUI.Logging;

namespace UniversalUI.Composition;

internal sealed class SingleFrameProvider : IFrameProvider
{
	private readonly SKImage _image;
	private readonly int _bytes;
	private bool _disposed;
	private readonly object _lock = new();

	public SingleFrameProvider(SKImage image)
	{
		_image = image;
		_bytes = _image.Info.BytesSize;
		// https://github.com/unoplatform/uno/issues/20285
		GC.AddMemoryPressure(_bytes);
	}

	public SKImage? CurrentImage => _image;

	public void Dispose()
	{
		lock (_lock)
		{
			if (!_disposed)
			{
				_disposed = true;
				_image.Dispose();
				GC.RemoveMemoryPressure(_bytes);
				GC.SuppressFinalize(this);
			}
			else
			{
				this.LogError()?.Error("Detected a double dispose.");
			}
		}
	}

	~SingleFrameProvider()
	{
		Dispose();
	}
}
