using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace SimpleControls
{
    [AnywhereControl]
<<<<<<< HEAD
    public interface IRadialGauge : IAnywhereControl
    {

    }

    public abstract class RadialGauge : AnywhereControl, IRadialGauge
=======
    public abstract class RadialGauge : AnywhereControl
>>>>>>> main
    {
        protected override IUIElement Build()
        {
            var blueBrush = SolidColorBrush().Color(Colors.Blue);
            return Rectangle().Width(50).Height(50).Stroke(blueBrush).Fill(Colors.Red);
        }
    }
}
