// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using CommonUI;
using AnywhereControls.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly BindableProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(Point), typeof(LineSegment), default(Point));
        
        public Point Point
        {
            get => (Point) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
    }
}
