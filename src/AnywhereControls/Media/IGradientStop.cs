using System.ComponentModel;
using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface IGradientStop : IUIObject
    {
        [DefaultValue(null)]
        // The default is Transparent
        Color Color { get; set; }

        [DefaultValue(0.0)]
        double Offset { get; set; }
    }
}
