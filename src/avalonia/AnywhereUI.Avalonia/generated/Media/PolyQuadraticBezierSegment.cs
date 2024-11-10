// This file is generated from IPolyQuadraticBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class PolyQuadraticBezierSegment : PathSegment, IPolyQuadraticBezierSegment
    {
        public static readonly Avalonia.StyledProperty<Points> PointsProperty = AvaloniaProperty.Register<PolyQuadraticBezierSegment, Points>(nameof(Points), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
