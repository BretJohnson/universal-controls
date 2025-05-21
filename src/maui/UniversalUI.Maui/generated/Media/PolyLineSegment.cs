// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace UniversalUI.Maui.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(PolyLineSegment), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
