using System.ComponentModel;
using Microsoft.Maui.Graphics;
using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.StandardUIStatics;

namespace SimpleControls
{
    [StandardControl]
    public interface IRadialGauge : IStandardControl
    {
        [DefaultValue(null)]
        IBrush? Fill { get; set; }
    }

    public class RadialGauge : StandardControl<IRadialGauge>
    {
        public RadialGauge(IRadialGauge control) : base(control)
        { }

        public override IUIElement? Build()
        {
            var blueBrush = SolidColorBrush().Color(Colors.Blue);
            return Rectangle().Width(50).Height(50).Stroke(blueBrush).Fill(Control.Fill);
        }
    }
}
