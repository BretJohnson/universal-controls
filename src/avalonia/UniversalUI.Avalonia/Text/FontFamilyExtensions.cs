using UniversalUI.Media;

namespace AnywhereControlsAvalonia.Text
{
    public static class FontFamilyExtensions
    {
        private static readonly Lazy<FontFamily> _defaultFontFamily = new Lazy<FontFamily>(() => new FontFamily(Avalonia.Media.FontFamily.Default.Name));

        /// <summary>
        /// Get the default font family for WPF, the same default used for the native WPF TextElement.FontFamily DependencyProperty default.
        /// </summary>
        public static FontFamily DefaultFontFamily => _defaultFontFamily.Value;

        public static Avalonia.Media.FontFamily ToAvaloniaFontFamily(this FontFamily fontFamily) =>
            new Avalonia.Media.FontFamily(fontFamily.Source);

        public static FontFamily ToAnywhereControlsFontFamily(Avalonia.Media.FontFamily fontFamily) =>
            new FontFamily(fontFamily.Name);
    }
}
