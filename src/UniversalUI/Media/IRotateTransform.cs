using System.ComponentModel;

namespace UniversalUI.Media
{
    [UIModelObject]
    public interface IRotateTransform : ITransform
    {
        [DefaultValue(0.0)]
        double Angle { get; set; }

        [DefaultValue(0.0)]
        double CenterX { get; set; }

        [DefaultValue(0.0)]
        double CenterY { get; set; }
    }
}
