using CommonUI;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface ILinearGradientBrush : IGradientBrush
    {
        Point StartPoint { get; set; }

        Point EndPoint { get; set; }
    }
}
