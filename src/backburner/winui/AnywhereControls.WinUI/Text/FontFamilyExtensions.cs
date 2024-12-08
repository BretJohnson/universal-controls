using System;
using AnywhereUI.Media;

namespace AnywhereControls.WinUI.Text
{
    public static class FontFamilyExtensions
    {
#if LATER
        private static Lazy<FontFamily> _defaultFontFamily = new Lazy<FontFamily>(() => new FontFamily(SystemFonts.MessageFontFamily.Source));
#else
        private static Lazy<FontFamily> _defaultFontFamily = new Lazy<FontFamily>(() => new FontFamily(""));
#endif

        /// <summary>
        /// Get the default font family for WPF, the same default used for the native WPF TextElement.FontFamily DependencyProperty default.
        /// </summary>
        public static FontFamily DefaultFontFamily => _defaultFontFamily.Value;

#if LATER
        public static Microsoft.UI.Xaml.Media.FontFamily ToWinUIFontFamily(this FontFamily fontFamily) =>
            new Microsoft.UI.Xaml.Media.FontFamily(fontFamily.Source);

        public static FontFamily FromWinUIFontFamily(Microsoft.UI.Xaml.Media.FontFamily fontFamily) =>
            new FontFamily(fontFamily.Source);
#endif
    }
}
