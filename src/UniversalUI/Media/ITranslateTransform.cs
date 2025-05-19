using System.ComponentModel;

namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface ITranslateTransform : ITransform
    {
        [DefaultValue(0.0)]
        double X { get; set; }

        [DefaultValue(0.0)]
        double Y { get; set; }
    }
}
