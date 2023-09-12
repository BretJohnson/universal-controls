using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace SimpleControls
{
    [AnywhereControl]
    public interface IRadialGauge : IAnywhereControl
    {
        //[DefaultValue(null)]
        //IBrush? Fill { get; set; }
    }

    public abstract class RadialGauge : AnywhereControl, IRadialGauge
    {
        protected override IUIElement Build()
        {
            var blueBrush = SolidColorBrush().Color(Colors.Blue);
            return Rectangle().Width(50).Height(50).Stroke(blueBrush).Fill(Colors.Red);
        }
    }
}
