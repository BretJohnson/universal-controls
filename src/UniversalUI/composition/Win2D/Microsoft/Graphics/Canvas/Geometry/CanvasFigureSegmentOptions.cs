// This file is copied, with modifications, from the Uno project

#nullable disable

using System;

namespace Microsoft.Graphics.Canvas.Geometry;

[Flags]
internal enum CanvasFigureSegmentOptions
{
	None = 0,
	ForceUnstroked = 1,
	ForceRoundLineJoin = 2
}
