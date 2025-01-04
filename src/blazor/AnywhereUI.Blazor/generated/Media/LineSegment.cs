// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereUI.Blazor.Media
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
