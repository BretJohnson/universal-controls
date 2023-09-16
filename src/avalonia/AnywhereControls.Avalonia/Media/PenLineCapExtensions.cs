using AnywhereControls.Media;

namespace AnywhereControls.Avalonia.Media
{
    public static class PenLineCapExtensions
    {
        public static global::Avalonia.Media.PenLineCap ToAvaloniaPenLineCap(this PenLineCap penLineCap) =>
            penLineCap switch
            {
                PenLineCap.Flat => global::Avalonia.Media.PenLineCap.Flat,
                PenLineCap.Round => global::Avalonia.Media.PenLineCap.Round,
                PenLineCap.Square => global::Avalonia.Media.PenLineCap.Square,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
            };

        public static PenLineCap ToStandardUIPenLineCap(this global::Avalonia.Media.PenLineCap penLineCap) =>
            penLineCap switch
            {
                global::Avalonia.Media.PenLineCap.Flat => PenLineCap.Flat,
                global::Avalonia.Media.PenLineCap.Round => PenLineCap.Round,
                global::Avalonia.Media.PenLineCap.Square => PenLineCap.Square,
                _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
            };
    }
}
