// This file is generated from IBezierSegment.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Media
{
    public class BezierSegment : PathSegment, IBezierSegment
    {
        public static readonly DependencyProperty Point1Property = PropertyUtils.Register(nameof(Point1), typeof(PointWinUI), typeof(BezierSegment), default(Point));
        public static readonly DependencyProperty Point2Property = PropertyUtils.Register(nameof(Point2), typeof(PointWinUI), typeof(BezierSegment), default(Point));
        public static readonly DependencyProperty Point3Property = PropertyUtils.Register(nameof(Point3), typeof(PointWinUI), typeof(BezierSegment), default(Point));
        
        public PointWinUI Point1
        {
            get => (PointWinUI) GetValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        Point IBezierSegment.Point1
        {
            get => Point1.Point;
            set => Point1 = new PointWinUI(value);
        }
        
        public PointWinUI Point2
        {
            get => (PointWinUI) GetValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
        Point IBezierSegment.Point2
        {
            get => Point2.Point;
            set => Point2 = new PointWinUI(value);
        }
        
        public PointWinUI Point3
        {
            get => (PointWinUI) GetValue(Point3Property);
            set => SetValue(Point3Property, value);
        }
        Point IBezierSegment.Point3
        {
            get => Point3.Point;
            set => Point3 = new PointWinUI(value);
        }
    }
}
