using System;
using System.Windows;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Wpf.Text
{
    public static class FontFamilyExtensions
    {
        private static Lazy<FontFamily> _defaultFontFamily = new Lazy<FontFamily>(() => new FontFamily(SystemFonts.MessageFontFamily.Source));

        /// <summary>
        /// Get the default font family for WPF, the same default used for the native WPF TextElement.FontFamily DependencyProperty default.
        /// </summary>
        public static FontFamily DefaultFontFamily => _defaultFontFamily.Value;

        public static System.Windows.Media.FontFamily ToWpfFontFamily(this FontFamily fontFamily) =>
            new System.Windows.Media.FontFamily(fontFamily.Source);

        public static FontFamily ToStandardUIFontFamily(System.Windows.Media.FontFamily fontFamily) =>
            new FontFamily(fontFamily.Source);
    }
}
