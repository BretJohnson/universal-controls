using AnywhereUI;
using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class Slider_Examples
    {
        [UIExample("Slider")]
        public static Slider SimpleSlider() =>
            Slider()
                .Value(5);

        [UIExample("Custom Slider")]
        public static Slider CustomSlider() =>
            Slider()
                .MinimumColor(Colors.Orange)
                .MaximumColor(Colors.Blue)
                .ThumbColor(Colors.Red)
                .Value(5);
    }
}
