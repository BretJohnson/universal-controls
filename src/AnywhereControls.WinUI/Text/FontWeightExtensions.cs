namespace AnywhereControls.WinUI.Text
{
    public static class FontWeightExtensions
    {
#if LATER
        public static global::Windows.UI.Text.FontWeight ToWinUIFontWeight(this FontWeight fontWeight) =>
            global::Windows.UI.Text.FontWeight.FromOpenTypeWeight(fontWeight.Weight);

        public static FontWeight FromWinUIFontWeight(global::Windows.UI.Text.FontWeight fontWeight) =>
            new FontWeight((ushort) fontWeight.ToOpenTypeWeight());
#endif
    }
}
