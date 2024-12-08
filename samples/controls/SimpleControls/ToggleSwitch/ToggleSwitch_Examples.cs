using AnywhereUI;
using AnywhereUI.Controls;
using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class ToggleSwitch_Examples
    {
        [UIExample("ToggleSwitch")]
        public static ToggleSwitch SimpleToggleSwitch() =>
            SimpleControls.SimpleControlsStatics.ToggleSwitch()
                .Width(40)
                .Height(30)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Red);

        [UIExample("ToggleSwitch with green thumb")]
        public static ToggleSwitch ToggleSwitchWithGreenThumb() =>
            ToggleSwitch()
                .Width(40)
                .Height(30d)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Green);
    }
}
