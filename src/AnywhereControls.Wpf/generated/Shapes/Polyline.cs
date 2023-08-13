// This file is generated from IPolyline.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using AnywhereControls.Shapes;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Shapes
{
    public class Polyline : Shape, IPolyline, IDrawable
    {
        public static readonly DependencyProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polyline), FillRule.EvenOdd);
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWpf), typeof(Polyline), PointsWpf.Default);
        
        public FillRule FillRule
        {
            get => (FillRule) GetValue(FillRuleProperty);
            set => SetValue(FillRuleProperty, value);
        }
        
        public PointsWpf Points
        {
            get => (PointsWpf) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyline.Points
        {
            get => Points.Points;
            set => Points = new PointsWpf(value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPolyline(this);
    }
}
