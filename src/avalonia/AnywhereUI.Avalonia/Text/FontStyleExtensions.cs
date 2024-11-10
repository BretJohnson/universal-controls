using AnywhereControls.Text;

namespace AnywhereControlsAvalonia.Text
{
    public static class FontStyleExtensions
    {
        public static Avalonia.Media.FontStyle ToAvaloniaFontStyle(this FontStyle fontStyle)
        {
            return fontStyle switch
            {
                FontStyle.Normal => Avalonia.Media.FontStyle.Normal,
                FontStyle.Oblique => Avalonia.Media.FontStyle.Oblique,
                FontStyle.Italic => Avalonia.Media.FontStyle.Italic,
                _ => throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}"),
            };
        }

        public static FontStyle ToStandardUIFontStyle(this Avalonia.Media.FontStyle fontStyle)
        {
            if (fontStyle == Avalonia.Media.FontStyle.Normal)
                return FontStyle.Normal;
            else if (fontStyle == Avalonia.Media.FontStyle.Oblique)
                return FontStyle.Oblique;
            else if (fontStyle == Avalonia.Media.FontStyle.Italic)
                return FontStyle.Italic;
            else throw new ArgumentOutOfRangeException(nameof(fontStyle), $"Invalid FontStyle value: {fontStyle}");
        }
    }
}
