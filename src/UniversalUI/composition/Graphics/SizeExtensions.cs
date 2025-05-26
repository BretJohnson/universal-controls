// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Graphics;

internal static class SizeExtensions
{
	internal static SizeInt32 ToSizeInt32(this Size size) => new SizeInt32((int)size.Width, (int)size.Height);
}
