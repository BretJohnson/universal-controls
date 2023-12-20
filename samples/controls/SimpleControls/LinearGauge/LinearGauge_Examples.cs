using Microsoft.ComponentModelEx;
using AnywhereControls;
using AnywhereControls.Controls;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class LinearGauge_Examples
    {
        [UIExample("LinearGauge")]
        public static ILinearGauge SimpleLinearGauge() =>
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
