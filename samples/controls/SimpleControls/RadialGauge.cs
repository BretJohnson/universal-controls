using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace SimpleControls
{
    [AnywhereControl]
    public abstract class RadialGauge : AnywhereControl
    {
        protected override IUIElement Build()
        {
            var blueBrush = SolidColorBrush().Color(Colors.Blue);
            return Rectangle().Width(50).Height(50).Stroke(blueBrush).Fill(Colors.Red);
        }
    }
}
