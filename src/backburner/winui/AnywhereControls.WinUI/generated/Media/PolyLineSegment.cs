// This file is generated from IPolyLineSegment.cs. Update the source file to change its contents.

using UniversalUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class PolyLineSegment : PathSegment, IPolyLineSegment
    {
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(PolyLineSegment), Points.Default);
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
