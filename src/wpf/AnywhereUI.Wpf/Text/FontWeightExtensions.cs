using AnywhereControls.Text;

namespace AnywhereControls.Wpf.Text
{
    public static class FontWeightExtensions
    {
        public static System.Windows.FontWeight ToWpfFontWeight(this FontWeight fontWeight) =>
            System.Windows.FontWeight.FromOpenTypeWeight(fontWeight.Weight);

        public static FontWeight ToAnywhereControlsFontWeight(this System.Windows.FontWeight fontWeight) =>
            new FontWeight((ushort)fontWeight.ToOpenTypeWeight());
    }
}
