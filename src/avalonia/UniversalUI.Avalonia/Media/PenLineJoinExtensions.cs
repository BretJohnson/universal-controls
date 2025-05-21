using UniversalUI.Media;

namespace AnywhereControlsAvalonia.Media
{
    public static class PenLineJoinExtensions
    {
        public static Avalonia.Media.PenLineJoin ToAvaloniaPenLineJoin(this PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                PenLineJoin.Miter => Avalonia.Media.PenLineJoin.Miter,
                PenLineJoin.Bevel => Avalonia.Media.PenLineJoin.Bevel,
                PenLineJoin.Round => Avalonia.Media.PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };

        public static PenLineJoin ToStandardUIPenLineJoin(this Avalonia.Media.PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                Avalonia.Media.PenLineJoin.Miter => PenLineJoin.Miter,
                Avalonia.Media.PenLineJoin.Bevel => PenLineJoin.Bevel,
                Avalonia.Media.PenLineJoin.Round => PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };
    }
}
