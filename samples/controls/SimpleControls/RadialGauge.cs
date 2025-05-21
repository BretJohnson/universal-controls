using UniversalUI;
using UniversalUI.Controls;
using UniversalUI.Media;
using UniversalUI.Shapes;
using static UniversalUI.UniversalUIStatics;

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
