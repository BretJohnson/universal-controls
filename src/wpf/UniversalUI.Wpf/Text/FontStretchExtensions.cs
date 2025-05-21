using UniversalUI.Text;

namespace UniversalUI.Wpf.Text
{
    public static class FontStretchExtensions
    {
        public static System.Windows.FontStretch ToWpfFontStretch(this FontStretch fontStretch) =>
            System.Windows.FontStretch.FromOpenTypeStretch(fontStretch == FontStretch.Undefined ? (int)FontStretch.Normal : (int)fontStretch);

        public static FontStretch ToStandardUIFontStretch(System.Windows.FontStretch fontStretch) =>
            (FontStretch)fontStretch.ToOpenTypeStretch();
    }
}
