// This file is copied, with modifications, from the Uno project

using System;
using SkiaSharp;

namespace UniversalUI.Composition;

internal interface IFrameProvider : IDisposable
{
	SKImage? CurrentImage { get; }
}
