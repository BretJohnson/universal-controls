// This file is generated from IPolygon.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using AnywhereUI.Shapes;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereUI.Maui.Shapes
{
    public class Polygon : Shape, IPolygon, IDrawable
    {
        public static readonly BindableProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polygon), FillRule.EvenOdd);
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(Points), typeof(Polygon), Points.Default);
        
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
