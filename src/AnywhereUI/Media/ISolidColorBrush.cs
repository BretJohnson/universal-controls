using System.ComponentModel;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(DefaultColor.Transparent)]
        Color Color { get; set; }
    }
}
