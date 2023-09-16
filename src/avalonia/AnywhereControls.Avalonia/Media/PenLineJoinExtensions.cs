using AnywhereControls.Media;

namespace AnywhereControls.Avalonia.Media
{
    public static class PenLineJoinExtensions
    {
        public static global::Avalonia.Media.PenLineJoin ToAvaloniaPenLineJoin(this PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                PenLineJoin.Miter => global::Avalonia.Media.PenLineJoin.Miter,
                PenLineJoin.Bevel => global::Avalonia.Media.PenLineJoin.Bevel,
                PenLineJoin.Round => global::Avalonia.Media.PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };

        public static PenLineJoin ToStandardUIPenLineJoin(this global::Avalonia.Media.PenLineJoin penLineJoin) =>
            penLineJoin switch
            {
                global::Avalonia.Media.PenLineJoin.Miter => PenLineJoin.Miter,
                global::Avalonia.Media.PenLineJoin.Bevel => PenLineJoin.Bevel,
                global::Avalonia.Media.PenLineJoin.Round => PenLineJoin.Round,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineJoin), $"Unknown PenLineJoin value {penLineJoin}")
            };
    }
}
