namespace AnywhereControls.WinUI
{
    public static class RectExtensions
    {
        public static global::Windows.Foundation.Rect ToWindowsFoundationRect(this Rect rect) =>
            new global::Windows.Foundation.Rect(rect.X, rect.Y, rect.Width, rect.Height);

        public static Rect ToStandardUIRect(this global::Windows.Foundation.Rect rect) =>
            new Rect(rect.X, rect.Y, rect.Width, rect.Height);
    }
}
