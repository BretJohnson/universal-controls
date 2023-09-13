// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using AnywhereControls.Media;

namespace AnywhereControls.Mac.Media
{
    public class PolyBezierSegment : PathSegment, IPolyBezierSegment
    {
        public static readonly UIProperty PointsProperty = new UIProperty(nameof(Points), Points.Default);
        
        public Points Points
        {
            get => (Points) GetNonNullValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
