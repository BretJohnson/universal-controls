using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface ISolidColorBrush : IBrush
    {
        [DefaultValue(null)]
        Color Color { get; set; }
    }
}
