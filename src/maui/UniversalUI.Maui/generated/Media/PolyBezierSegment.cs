// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace UniversalUI.Maui.Media
{
    public class PolyBezierSegment : PathSegment, IPolyBezierSegment
    {
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(PolyBezierSegment), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
