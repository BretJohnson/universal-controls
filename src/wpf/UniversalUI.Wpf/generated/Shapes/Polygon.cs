// This file is generated from IPolygon.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using AnywhereUI.Shapes;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereUI.Wpf.Shapes
{
    public class Polygon : Shape, IPolygon, IDrawable
    {
        public static readonly DependencyProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polygon), FillRule.EvenOdd);
        public static readonly DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(Polygon), Points.Default);
        
        public FillRule FillRule
        {
            get => (FillRule) GetValue(FillRuleProperty);
            set => SetValue(FillRuleProperty, value);
        }
        
        public Points Points
        {
            get => (Points) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPolygon(this);
    }
}
