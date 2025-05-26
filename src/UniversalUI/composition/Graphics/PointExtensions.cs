// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Graphics;

internal static class PointExtensions
{
	internal static PointInt32 ToPointInt32(this Point point) => new PointInt32((int)point.X, (int)point.Y);
}
