// This file is generated from IArcSegment.cs. Update the source file to change its contents.

using CommonUI;
using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class ArcSegment : PathSegment, IArcSegment
    {
        public static readonly DependencyProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(PointWinUI), typeof(ArcSegment), default(Point));
        public static readonly DependencyProperty SizeProperty = PropertyUtils.Register(nameof(Size), typeof(SizeWinUI), typeof(ArcSegment), default(Size));
        public static readonly DependencyProperty RotationAngleProperty = PropertyUtils.Register(nameof(RotationAngle), typeof(double), typeof(ArcSegment), 0.0);
        public static readonly DependencyProperty IsLargeArcProperty = PropertyUtils.Register(nameof(IsLargeArc), typeof(bool), typeof(ArcSegment), false);
        public static readonly DependencyProperty SweepDirectionProperty = PropertyUtils.Register(nameof(SweepDirection), typeof(SweepDirection), typeof(ArcSegment), SweepDirection.Counterclockwise);
        
        public PointWinUI Point
        {
            get => (PointWinUI) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        Point IArcSegment.Point
        {
            get => Point.Point;
            set => Point = new PointWinUI(value);
        }
        
        public SizeWinUI Size
        {
            get => (SizeWinUI) GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        Size IArcSegment.Size
        {
            get => Size.Size;
            set => Size = new SizeWinUI(value);
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
