// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsMaui), typeof(PolyLineSegment), PointsMaui.Default);
        
        public PointsMaui Points
        {
            get => (PointsMaui) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyLineSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsMaui(value);
        }
    }
}
