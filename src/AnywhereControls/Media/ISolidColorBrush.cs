using System.ComponentModel;
using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(DefaultColor.Transparent)]
        Color Color { get; set; }
    }
}
