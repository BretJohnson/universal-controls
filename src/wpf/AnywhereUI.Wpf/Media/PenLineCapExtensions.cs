using System;
using AnywhereUI.Media;

namespace AnywhereUI.Wpf.Media
{
    public static class PenLineCapExtensions
    {
        public static System.Windows.Media.PenLineCap ToWpfPenLineCap(this PenLineCap penLineCap) =>
            penLineCap switch
            {
                PenLineCap.Flat => System.Windows.Media.PenLineCap.Flat,
                PenLineCap.Round => System.Windows.Media.PenLineCap.Round,
                PenLineCap.Square => System.Windows.Media.PenLineCap.Square,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
            };

        public static PenLineCap ToStandardUIPenLineCap(this System.Windows.Media.PenLineCap penLineCap) =>
            penLineCap switch
            {
                System.Windows.Media.PenLineCap.Flat => PenLineCap.Flat,
                System.Windows.Media.PenLineCap.Round => PenLineCap.Round,
                System.Windows.Media.PenLineCap.Square => PenLineCap.Square,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
            };
    }
}
