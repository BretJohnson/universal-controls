// This file is generated from IPolyQuadraticBezierSegment.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereUI.Blazor.Media
{
    public class PolyQuadraticBezierSegment : PathSegment, IPolyQuadraticBezierSegment
    {
        public static readonly UIProperty PointsProperty = new UIProperty(nameof(Points), Points.Default);
        
        [Parameter]
        public Points Points
        {
            get => (Points) GetNonNullValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
    }
}
