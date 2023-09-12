using AnywhereControls.Text;

namespace AnywhereControls.Maui.Text
{
    public struct FontWeightMaui
    {
        public static readonly FontWeightMaui Default = new FontWeightMaui(FontWeights.Normal);

        public static FontWeightMaui FromFontWeight(FontWeight fontWeight) => new FontWeightMaui(fontWeight);

        // Auto properties
        public FontWeight FontWeight { get; }

        public FontWeightMaui(FontWeight fontWeight)
        {
            FontWeight = fontWeight;
        }
    }
}
