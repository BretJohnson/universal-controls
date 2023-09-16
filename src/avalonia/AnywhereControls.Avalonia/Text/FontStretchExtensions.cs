using AnywhereControls.Text;

namespace AnywhereControls.Avalonia.Text
{
    public static class FontStretchExtensions
    {
        public static global::Avalonia.Media.FontStretch ToAvaloniaFontStretch(this FontStretch fontStretch) =>
            (global::Avalonia.Media.FontStretch) (fontStretch == FontStretch.Undefined ? (int)FontStretch.Normal : (int)fontStretch);

        public static FontStretch ToAnywhereControlsFontStretch(global::Avalonia.Media.FontStretch fontStretch) =>
            (FontStretch)fontStretch;
    }
}
