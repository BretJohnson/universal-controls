// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using AnywhereControls.Media;

namespace AnywhereControls.Mac.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly UIProperty PointsProperty = new UIProperty(nameof(Points), Points.Default);
        
        public Points Points
        {
            get => (Points) GetNonNullValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
