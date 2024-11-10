// This file is generated from IArcSegment.cs. Update the source file to change its contents.

using AnywhereControls;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class ArcSegment : PathSegment, IArcSegment
    {
        public static readonly Avalonia.StyledProperty<Point> PointProperty = AvaloniaProperty.Register<ArcSegment, Point>(nameof(Point), default(Point));
        public static readonly Avalonia.StyledProperty<Size> SizeProperty = AvaloniaProperty.Register<ArcSegment, Size>(nameof(Size), default(Size));
        public static readonly Avalonia.StyledProperty<double> RotationAngleProperty = AvaloniaProperty.Register<ArcSegment, double>(nameof(RotationAngle), 0.0);
        public static readonly Avalonia.StyledProperty<bool> IsLargeArcProperty = AvaloniaProperty.Register<ArcSegment, bool>(nameof(IsLargeArc), false);
        public static readonly Avalonia.StyledProperty<SweepDirection> SweepDirectionProperty = AvaloniaProperty.Register<ArcSegment, SweepDirection>(nameof(SweepDirection), SweepDirection.Counterclockwise);
        
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
