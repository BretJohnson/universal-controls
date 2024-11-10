using System;
using AnywhereControls.Media;

namespace AnywhereControls.Wpf.Media
{
    public static class PenLineJoinExtensions
    {
        public static System.Windows.Media.PenLineJoin ToWpfPenLineJoin(this PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                PenLineJoin.Miter => System.Windows.Media.PenLineJoin.Miter,
                PenLineJoin.Bevel => System.Windows.Media.PenLineJoin.Bevel,
                PenLineJoin.Round => System.Windows.Media.PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };

        public static PenLineJoin ToStandardUIPenLineJoin(this System.Windows.Media.PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                System.Windows.Media.PenLineJoin.Miter => PenLineJoin.Miter,
                System.Windows.Media.PenLineJoin.Bevel => PenLineJoin.Bevel,
                System.Windows.Media.PenLineJoin.Round => PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };
    }
}
