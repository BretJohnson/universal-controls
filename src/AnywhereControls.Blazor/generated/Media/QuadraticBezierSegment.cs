// This file is generated from IQuadraticBezierSegment.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.Maui.Graphics;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class QuadraticBezierSegment : PathSegment, IQuadraticBezierSegment
    {
        public static readonly UIProperty Point1Property = new UIProperty(nameof(Point1), default(Point));
        public static readonly UIProperty Point2Property = new UIProperty(nameof(Point2), default(Point));
        
        [Parameter]
        public Point Point1
        {
            get => (Point) GetNonNullValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        
        [Parameter]
        public Point Point2
        {
            get => (Point) GetNonNullValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
    }
}
