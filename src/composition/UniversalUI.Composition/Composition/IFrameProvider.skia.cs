#nullable enable

using System;
using SkiaSharp;

namespace UniversalUI.Composition;

internal interface IFrameProvider : IDisposable
{
	SKImage? CurrentImage { get; }
}
