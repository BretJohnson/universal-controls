using System.ComponentModel;

namespace UniversalUI.Media
{
    [UIModelObject]
    public interface IGradientStop : IUIObject
    {
        [DefaultValue(DefaultColor.Transparent)]
        Color Color { get; set; }

        [DefaultValue(0.0)]
        double Offset { get; set; }
    }
}
