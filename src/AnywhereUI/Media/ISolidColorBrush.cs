using System.ComponentModel;

namespace AnywhereUI.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(DefaultColor.Transparent)]
        Color Color { get; set; }
    }
}
