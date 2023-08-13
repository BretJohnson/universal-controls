using CoreGraphics;

namespace Microsoft.StandardUI.Mac
{
    public static class SizeExtensions
    {
        public static CGSize ToCGSize(this Size size) => new CGSize(size.Width, size.Height);

        public static Size ToStandardUISize(this CGSize size) => new Size(size.Width, size.Height);
    }
}
