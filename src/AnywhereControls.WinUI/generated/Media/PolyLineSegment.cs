// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWinUI), typeof(PolyLineSegment), PointsWinUI.Default);
        
        public PointsWinUI Points
        {
            get => (PointsWinUI) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyLineSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsWinUI(value);
        }
    }
}
