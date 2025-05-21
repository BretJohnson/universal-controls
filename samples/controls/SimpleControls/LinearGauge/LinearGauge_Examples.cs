using UniversalUI;
using UniversalUI.Controls;
using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class LinearGauge_Examples
    {
        [Example("LinearGauge")]
        public static LinearGauge SimpleLinearGauge() =>
            LinearGauge()
                .Width(60)
                .Height(200)
                .BackgroundColor(Colors.LightGray)
                .ProgressColor(Colors.DarkGray)
                .RangeStart(0)
                .RangeEnd(100)
                .Value(50);
    }
}
