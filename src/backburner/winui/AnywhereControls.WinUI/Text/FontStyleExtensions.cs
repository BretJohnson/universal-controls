using System;
using UniversalUI.Text;

namespace AnywhereControls.WinUI.Text
{
    public static class FontStyleExtensions
    {
        public static global::Windows.UI.Text.FontStyle ToWinUIFontStyle(this FontStyle fontStyle)
        {
            return fontStyle switch
            {
                FontStyle.Normal => global::Windows.UI.Text.FontStyle.Normal,
                FontStyle.Oblique => global::Windows.UI.Text.FontStyle.Oblique,
                FontStyle.Italic => global::Windows.UI.Text.FontStyle.Italic,
                _ => throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}"),
            };
        }

        public static FontStyle ToStandardUIFontStyle(global::Windows.UI.Text.FontStyle fontStyle)
        {
            if (fontStyle == global::Windows.UI.Text.FontStyle.Normal)
                return FontStyle.Normal;
            else if (fontStyle == global::Windows.UI.Text.FontStyle.Oblique)
                return FontStyle.Oblique;
            else if (fontStyle == global::Windows.UI.Text.FontStyle.Italic)
                return FontStyle.Italic;
            else throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}");
        }
    }
}
