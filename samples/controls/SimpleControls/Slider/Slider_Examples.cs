using Microsoft.ComponentModelEx;
using AnywhereControls;
using AnywhereControls.Controls;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.StandardControls
{
    public class Slider_Examples
    {
        [UIExample("Slider")]
        public static ISlider SimpleSlider() =>
            Slider()
                .Value(5);

        [UIExample("Custom Slider")]
        public static ISlider CustomSlider() =>
            Slider()
                .MinimumColor(Colors.Orange)
                .MaximumColor(Colors.Blue)
                .ThumbColor(Colors.Red)
                .Value(5);
    }
}
