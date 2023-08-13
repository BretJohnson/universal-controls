using System.ComponentModel;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface IScaleTransform : ITransform
    {
        [DefaultValue(0.0)]
        double CenterX { get; set; }

        [DefaultValue(0.0)]
        double CenterY { get; set; }

        [DefaultValue(1.0)]
        double ScaleX { get; set; }

        [DefaultValue(1.0)]
        double ScaleY { get; set; }
    }
}
