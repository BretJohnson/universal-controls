using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ILinearGradientBrush : IGradientBrush
    {
        Point StartPoint { get; set; }

        Point EndPoint { get; set; }
    }
}
