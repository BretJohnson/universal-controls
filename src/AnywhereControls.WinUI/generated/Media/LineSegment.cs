// This file is generated from ILineSegment.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class LineSegment : PathSegment, ILineSegment
    {
        public static readonly DependencyProperty PointProperty = PropertyUtils.Register(nameof(Point), typeof(PointWinUI), typeof(LineSegment), default(Point));
        
        public PointWinUI Point
        {
            get => (PointWinUI) GetValue(PointProperty);
            set => SetValue(PointProperty, value);
        }
        Point ILineSegment.Point
        {
            get => Point.Point;
            set => Point = new PointWinUI(value);
        }
    }
}
