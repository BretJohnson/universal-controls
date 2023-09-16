using AnywhereControls.Text;

namespace AnywhereControls.Avalonia.Text
{
    public static class FontWeightExtensions
    {
        public static global::Avalonia.Media.FontWeight ToAvaloniaFontWeight(this FontWeight fontWeight) =>
            (global::Avalonia.Media.FontWeight)fontWeight.Weight;

        public static FontWeight ToAnywhereControlsFontWeight(this global::Avalonia.Media.FontWeight fontWeight) =>
            new FontWeight((ushort)fontWeight);
    }
}
