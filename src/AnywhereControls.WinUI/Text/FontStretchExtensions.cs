namespace Microsoft.StandardUI.WinUI.Text
{
    public static class FontStretchExtensions
    {
#if LATER
        public static global::Windows.UI.Text.FontStretch ToWinUIFontStretch(this FontStretch fontStretch) =>
            global::Windows.UI.Text.FontStretch.FromOpenTypeStretch(fontStretch == FontStretch.Undefined ? (int)FontStretch.Normal : (int)fontStretch);

        public static FontStretch FromWinUIFontStretch(global::Windows.UI.Text.FontStretch fontStretch) =>
            (FontStretch)fontStretch.ToOpenTypeStretch();
#endif
    }
}
