// This file is generated from IPolyline.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using AnywhereControls.Shapes;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereControls.Maui.Shapes
{
    public class Polyline : Shape, IPolyline, IDrawable
    {
        public static readonly BindableProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(Polyline), FillRule.EvenOdd);
        public static readonly BindableProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsMaui), typeof(Polyline), PointsMaui.Default);
        
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
        Points IPolyline.Points
        {
            get => Points.Points;
            set => Points = new PointsMaui(value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawPolyline(this);
    }
}
