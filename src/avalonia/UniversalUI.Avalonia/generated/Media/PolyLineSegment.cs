// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly Avalonia.StyledProperty<Points> PointsProperty = AvaloniaProperty.Register<PolyLineSegment, Points>(nameof(Points), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
