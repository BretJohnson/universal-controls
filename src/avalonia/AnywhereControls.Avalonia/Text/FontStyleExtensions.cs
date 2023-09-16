using System;
using AnywhereControls.Text;

namespace AnywhereControls.Avalonia.Text
{
    public static class FontStyleExtensions
    {
        public static global::Avalonia.Media.FontStyle ToAvaloniaFontStyle(this FontStyle fontStyle)
        {
            return fontStyle switch
            {
                FontStyle.Normal => global::Avalonia.Media.FontStyle.Normal,
                FontStyle.Oblique => global::Avalonia.Media.FontStyle.Oblique,
                FontStyle.Italic => global::Avalonia.Media.FontStyle.Italic,
                _ => throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}"),
            };
        }

        public static FontStyle ToStandardUIFontStyle(this global::Avalonia.Media.FontStyle fontStyle)
        {
            if (fontStyle == global::Avalonia.Media.FontStyle.Normal)
                return FontStyle.Normal;
            else if (fontStyle == global::Avalonia.Media.FontStyle.Oblique)
                return FontStyle.Oblique;
            else if (fontStyle == global::Avalonia.Media.FontStyle.Italic)
                return FontStyle.Italic;
            else throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}");
        }
    }
}
