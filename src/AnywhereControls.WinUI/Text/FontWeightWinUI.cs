using Microsoft.StandardUI.Text;

namespace Microsoft.StandardUI.WinUI.Text
{
    public struct FontWeightWinUI
    {
        public static readonly FontWeightWinUI Default = new FontWeightWinUI(FontWeights.Normal);

        public static FontWeightWinUI FromFontWeight(FontWeight fontWeight) => new FontWeightWinUI(fontWeight);

        public FontWeight FontWeight { get; }

        public FontWeightWinUI(FontWeight fontWeight)
        {
            FontWeight = fontWeight;
        }
    }
}
