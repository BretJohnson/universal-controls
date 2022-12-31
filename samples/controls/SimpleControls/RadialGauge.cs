using System.ComponentModel;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;
using static Microsoft.StandardUI.StandardUIStatics;

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
