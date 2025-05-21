using System.ComponentModel;

namespace UniversalUI.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(DefaultColor.Transparent)]
        Color Color { get; set; }
    }
}
