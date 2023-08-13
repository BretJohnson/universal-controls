using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(null)]
        Color Color { get; set; }
    }
}
