// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly UIProperty PointProperty = new UIProperty(nameof(Point), default(Point));
        
        [Parameter]
        public Point Point
        {
            get => (Point) GetNonNullValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
    }
}
