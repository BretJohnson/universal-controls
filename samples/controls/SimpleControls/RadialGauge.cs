using AnywhereUI;
using AnywhereUI.Controls;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using static AnywhereUI.AnywhereUIStatics;

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
