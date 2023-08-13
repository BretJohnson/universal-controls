using CoreGraphics;

namespace Microsoft.StandardUI.Mac
{
    public static class RectExtensions
    {
        public static CGRect ToCGRect(this Rect rect) => new CGRect(rect.X, rect.Y, rect.Width, rect.Height);

        public static Rect ToStandardUIRect(this CGRect rect) => new Rect(rect.X, rect.Y, rect.Width, rect.Height);
    }
}
