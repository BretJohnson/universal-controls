// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using AnywhereControls.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly DependencyProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(PointWpf), typeof(LineSegment), default(Point));
        
        public PointWpf Point
        {
            get => (PointWpf) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        Point ILineSegment.Point
        {
            get => Point.Point;
            set => Point = new PointWpf(value);
        }
    }
}
