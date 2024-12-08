// This file is generated from IPolygon.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Shapes
{
    public class Polygon : Shape, IPolygon, IDrawable
    {
        public static readonly Avalonia.StyledProperty<FillRule> FillRuleProperty = AvaloniaProperty.Register<Polygon, FillRule>(nameof(FillRule), FillRule.EvenOdd);
        public static readonly Avalonia.StyledProperty<Points> PointsProperty = AvaloniaProperty.Register<Polygon, Points>(nameof(Points), Points.Default);
        
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
