// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.Maui.Graphics;
using Microsoft.AspNetCore.Components;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Blazor.Media
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
