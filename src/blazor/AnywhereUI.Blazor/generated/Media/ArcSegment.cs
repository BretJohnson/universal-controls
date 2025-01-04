// This file is generated from IArcSegment.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereUI.Blazor.Media
{
    public class ArcSegment : PathSegment, IArcSegment
    {
        public static readonly UIProperty PointProperty = new UIProperty(nameof(Point), default(Point));
        public static readonly UIProperty SizeProperty = new UIProperty(nameof(Size), default(Size));
        public static readonly UIProperty RotationAngleProperty = new UIProperty(nameof(RotationAngle), 0.0);
        public static readonly UIProperty IsLargeArcProperty = new UIProperty(nameof(IsLargeArc), false);
        public static readonly UIProperty SweepDirectionProperty = new UIProperty(nameof(SweepDirection), SweepDirection.Counterclockwise);
        
        [Parameter]
        public Point Point
        {
            get => (Point) GetNonNullValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        
        [Parameter]
        public Size Size
        {
            get => (Size) GetNonNullValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        
        [Parameter]
        public double RotationAngle
        {
            get => (double) GetNonNullValue(RotationAngleProperty);
            set => SetValue(RotationAngleProperty, value);
        }
        
        [Parameter]
        public bool IsLargeArc
        {
            get => (bool) GetNonNullValue(IsLargeArcProperty);
            set => SetValue(IsLargeArcProperty, value);
        }
        
        [Parameter]
        public SweepDirection SweepDirection
        {
            get => (SweepDirection) GetNonNullValue(SweepDirectionProperty);
            set => SetValue(SweepDirectionProperty, value);
        }
    }
}
