// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using UniversalUI.Media;

namespace AnywhereControls.Blazor.Media
{
    public class PolyBezierSegment : PathSegment, IPolyBezierSegment
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
