// This file is copied, with modifications, from the Uno project

#nullable disable

namespace UniversalUI.Graphics.Interop.Direct2D;

internal struct D2D1ArcSegment
{
	public Point Point;
	public Size Size;
	public float RotationAngle;
	public D2D1SweepDirection SweepDirection;
	public D2D1ArcSize ArcSize;
}
