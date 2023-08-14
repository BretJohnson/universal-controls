using System.ComponentModel;
using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(null)]
        Color Color { get; set; }
    }
}
