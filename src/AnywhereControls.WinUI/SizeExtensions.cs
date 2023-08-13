namespace Microsoft.StandardUI.WinUI
{
    public static class SizeExtensions
    {
        public static global::Windows.Foundation.Size ToWindowsFoundationSize(this Size size) =>
            new global::Windows.Foundation.Size(size.Width, size.Height);

        public static Size ToStandardUISize(this global::Windows.Foundation.Size size) =>
            new Size(size.Width, size.Height);
    }
}
