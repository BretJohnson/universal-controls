using UniversalUI.Text;

namespace AnywhereControlsAvalonia.Text
{
    public static class FontWeightExtensions
    {
        public static Avalonia.Media.FontWeight ToAvaloniaFontWeight(this FontWeight fontWeight) =>
            (Avalonia.Media.FontWeight)fontWeight.Weight;

        public static FontWeight ToAnywhereControlsFontWeight(this Avalonia.Media.FontWeight fontWeight) =>
            new FontWeight((ushort)fontWeight);
    }
}
