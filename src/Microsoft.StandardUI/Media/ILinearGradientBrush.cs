using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface ILinearGradientBrush : IGradientBrush
    {
        Point StartPoint { get; set; }

        Point EndPoint { get; set; }
    }
}
