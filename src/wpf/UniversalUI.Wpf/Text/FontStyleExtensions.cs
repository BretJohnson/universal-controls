using System;
using AnywhereUI.Text;

namespace AnywhereUI.Wpf.Text
{
    public static class FontStyleExtensions
    {
        public static System.Windows.FontStyle ToWpfFontStyle(this FontStyle fontStyle)
        {
            return fontStyle switch
            {
                FontStyle.Normal => System.Windows.FontStyles.Normal,
                FontStyle.Oblique => System.Windows.FontStyles.Oblique,
                FontStyle.Italic => System.Windows.FontStyles.Italic,
                _ => throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}"),
            };
        }

        public static FontStyle ToStandardUIFontStyle(this System.Windows.FontStyle fontStyle)
        {
            if (fontStyle == System.Windows.FontStyles.Normal)
                return FontStyle.Normal;
            else if (fontStyle == System.Windows.FontStyles.Oblique)
                return FontStyle.Oblique;
            else if (fontStyle == System.Windows.FontStyles.Italic)
                return FontStyle.Italic;
            else throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}");
        }
    }
}
