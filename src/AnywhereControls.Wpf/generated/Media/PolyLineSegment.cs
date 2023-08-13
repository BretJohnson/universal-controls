// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWpf), typeof(PolyLineSegment), PointsWpf.Default);
        
        public PointsWpf Points
        {
            get => (PointsWpf) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyLineSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsWpf(value);
        }
    }
}
