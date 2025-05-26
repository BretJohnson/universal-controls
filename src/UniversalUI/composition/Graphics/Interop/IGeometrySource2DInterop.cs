// This file is copied, with modifications, from the Uno project

#nullable disable

using System;
using System.Runtime.InteropServices;
using UniversalUI.Graphics.Interop.Direct2D;

namespace Windows.Graphics.Interop;

[Guid("0657AF73-53FD-47CF-84FF-C8492D2A80A3")]
internal interface IGeometrySource2DInterop
{
	ID2D1Geometry GetGeometry();

	ID2D1Geometry TryGetGeometryUsingFactory(/*ID2D1Factory*/ object factory);
}
