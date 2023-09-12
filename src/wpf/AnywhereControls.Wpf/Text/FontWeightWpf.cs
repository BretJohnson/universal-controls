using AnywhereControls.Text;

namespace AnywhereControls.Wpf.Text
{
    public struct FontWeightWpf
    {
        public static readonly FontWeightWpf Default = new FontWeightWpf(FontWeights.Normal);

        public static FontWeightWpf FromFontWeight(FontWeight fontWeight) => new FontWeightWpf(fontWeight);

        public FontWeight FontWeight { get; }

        public FontWeightWpf(FontWeight fontWeight)
        {
            FontWeight = fontWeight;
        }
    }
}
