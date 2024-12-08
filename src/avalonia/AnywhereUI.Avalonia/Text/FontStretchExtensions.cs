using AnywhereUI.Text;

namespace AnywhereControlsAvalonia.Text
{
    public static class FontStretchExtensions
    {
        public static Avalonia.Media.FontStretch ToAvaloniaFontStretch(this FontStretch fontStretch) =>
            (Avalonia.Media.FontStretch) (fontStretch == FontStretch.Undefined ? (int)FontStretch.Normal : (int)fontStretch);

        public static FontStretch ToAnywhereControlsFontStretch(Avalonia.Media.FontStretch fontStretch) =>
            (FontStretch)fontStretch;
    }
}
