// This file is copied, with modifications, from the Uno project

#nullable disable

using System;
using System.Runtime.InteropServices;

namespace UniversalUI.Graphics.Interop.Direct2D;

[Guid("2CD906A2-12E2-11DC-9FED-001143A055F9")]
internal interface ID2D1RectangleGeometry : ID2D1Geometry
{
	Rect GetRect();
}
