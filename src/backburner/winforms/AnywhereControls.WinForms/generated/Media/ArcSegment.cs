// This file is generated from IArcSegment.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;

namespace AnywhereControls.WinForms.Media
{
    public class ArcSegment : PathSegment, IArcSegment
    {
        public static readonly UIProperty PointProperty = new UIProperty(nameof(Point), default(Point));
        public static readonly UIProperty SizeProperty = new UIProperty(nameof(Size), default(Size));
        public static readonly UIProperty RotationAngleProperty = new UIProperty(nameof(RotationAngle), 0.0);
        public static readonly UIProperty IsLargeArcProperty = new UIProperty(nameof(IsLargeArc), false);
        public static readonly UIProperty SweepDirectionProperty = new UIProperty(nameof(SweepDirection), SweepDirection.Counterclockwise);
        
        public Point Point
        {
            get => (Point) GetNonNullValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        
        public Size Size
        {
            get => (Size) GetNonNullValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        
        public double RotationAngle
        {
            get => (double) GetNonNullValue(RotationAngleProperty);
            set => SetValue(RotationAngleProperty, value);
        }
        
        public bool IsLargeArc
        {
            get => (bool) GetNonNullValue(IsLargeArcProperty);
            set => SetValue(IsLargeArcProperty, value);
        }
        
        public SweepDirection SweepDirection
        {
            get => (SweepDirection) GetNonNullValue(SweepDirectionProperty);
            set => SetValue(SweepDirectionProperty, value);
        }
    }
}
