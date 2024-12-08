// This file is generated from IPolyQuadraticBezierSegment.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereUI.Maui.Media
{
    public class PolyQuadraticBezierSegment : PathSegment, IPolyQuadraticBezierSegment
    {
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(PolyQuadraticBezierSegment), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
