// This file is generated from IPolygon.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;
using DependencyProperty = System.Windows.DependencyProperty;

namespace Microsoft.StandardUI.Wpf.Shapes
{
    public class Polygon : Shape, IPolygon, IDrawable
    {
        public static readonly DependencyProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polygon), FillRule.EvenOdd);
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWpf), typeof(Polygon), PointsWpf.Default);
        
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
        Points IPolygon.Points
        {
            get => Points.Points;
            set => Points = new PointsWpf(value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPolygon(this);
    }
}
