// This file is generated from IArcSegment.cs. Update the source file to change its contents.

using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;
using SweepDirection = AnywhereControls.Media.SweepDirection;

namespace UniversalUI.Maui.Media
{
    public class ArcSegment : PathSegment, IArcSegment
    {
        public static readonly BindableProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(Point), typeof(ArcSegment), default(Point));
        public static readonly BindableProperty SizeProperty = PropertyUtils.Register(nameof(Size), typeof(Size), typeof(ArcSegment), default(Size));
        public static readonly BindableProperty RotationAngleProperty = PropertyUtils.Register(nameof(RotationAngle), typeof(double), typeof(ArcSegment), 0.0);
        public static readonly BindableProperty IsLargeArcProperty = PropertyUtils.Register(nameof(IsLargeArc), typeof(bool), typeof(ArcSegment), false);
        public static readonly BindableProperty SweepDirectionProperty = PropertyUtils.Register(nameof(SweepDirection), typeof(SweepDirection), typeof(ArcSegment), SweepDirection.Counterclockwise);
        
        public Point Point
        {
            get => (Point) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        
        public Size Size
        {
            get => (Size) GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        
        public double RotationAngle
        {
            get => (double) GetValue(RotationAngleProperty);
            set => SetValue(RotationAngleProperty, value);
        }
        
        public bool IsLargeArc
        {
            get => (bool) GetValue(IsLargeArcProperty);
            set => SetValue(IsLargeArcProperty, value);
        }
        
        public SweepDirection SweepDirection
        {
            get => (SweepDirection) GetValue(SweepDirectionProperty);
            set => SetValue(SweepDirectionProperty, value);
        }
    }
}
