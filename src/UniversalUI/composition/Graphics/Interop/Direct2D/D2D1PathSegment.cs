// This file is copied, with modifications, from the Uno project

#nullable disable

using System;

namespace UniversalUI.Graphics.Interop.Direct2D;

[Flags]
internal enum D2D1PathSegment
{
	None = 0,
	ForceUnstroked = 1,
	ForceRoundLineJoin = 2
}
