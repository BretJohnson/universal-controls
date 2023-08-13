// This file is generated from IPolygon.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using AnywhereControls.Shapes;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Shapes
{
    public class Polygon : Shape, IPolygon, IDrawable
    {
        public static readonly BindableProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polygon), FillRule.EvenOdd);
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsMaui), typeof(Polygon), PointsMaui.Default);
        
        public FillRule FillRule
        {
            get => (FillRule) GetValue(FillRuleProperty);
            set => SetValue(FillRuleProperty, value);
        }
        
        public PointsMaui Points
        {
            get => (PointsMaui) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolygon.Points
        {
            get => Points.Points;
            set => Points = new PointsMaui(value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPolygon(this);
    }
}
