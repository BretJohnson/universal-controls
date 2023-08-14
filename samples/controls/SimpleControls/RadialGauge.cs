using System.ComponentModel;
using CommonUI;
using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

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
