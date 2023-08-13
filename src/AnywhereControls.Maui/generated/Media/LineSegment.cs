// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using AnywhereControls.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly BindableProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(PointMaui), typeof(LineSegment), default(Point));
        
        public PointMaui Point
        {
            get => (PointMaui) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        Point ILineSegment.Point
        {
            get => Point.Point;
            set => Point = new PointMaui(value);
        }
    }
}
