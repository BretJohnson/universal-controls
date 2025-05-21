namespace UniversalUI.Maui
{
    public static class SizeExtensions
    {
        public static Microsoft.Maui.Graphics.Size ToMauiSize(this Size size) =>
            new Microsoft.Maui.Graphics.Size(size.Width, size.Height);

        public static Size ToAnywhereControlsSize(this Microsoft.Maui.Graphics.Size size) =>
            new Size(size.Width, size.Height);
    }
}
