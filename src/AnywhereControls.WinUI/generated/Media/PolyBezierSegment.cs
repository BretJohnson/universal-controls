// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class PolyBezierSegment : PathSegment, IPolyBezierSegment
    {
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWinUI), typeof(PolyBezierSegment), PointsWinUI.Default);
        
        public PointsWinUI Points
        {
            get => (PointsWinUI) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyBezierSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsWinUI(value);
        }
    }
}
