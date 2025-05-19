using System.ComponentModel;

namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface IGeometry : IUIObject
    {
        [DefaultValue(0.25)]
        double StandardFlatteningTolerance { get; set; }

        [DefaultValue(null)]
        ITransform Transform { get; set; }
    }
}
