using UniversalUI.Media;

namespace AnywhereControlsAvalonia.Media;

public static class PenLineCapExtensions
{
    public static Avalonia.Media.PenLineCap ToAvaloniaPenLineCap(this PenLineCap penLineCap) =>
        penLineCap switch
        {
            PenLineCap.Flat => Avalonia.Media.PenLineCap.Flat,
            PenLineCap.Round => Avalonia.Media.PenLineCap.Round,
            PenLineCap.Square => Avalonia.Media.PenLineCap.Square,
            _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
        };

    public static PenLineCap ToStandardUIPenLineCap(this Avalonia.Media.PenLineCap penLineCap) =>
        penLineCap switch
        {
            Avalonia.Media.PenLineCap.Flat => PenLineCap.Flat,
            Avalonia.Media.PenLineCap.Round => PenLineCap.Round,
            Avalonia.Media.PenLineCap.Square => PenLineCap.Square,
            _ => throw new ArgumentOutOfRangeException(nameof(penLineCap), $"Unknown PenLineCap value {penLineCap}")
        };
}
