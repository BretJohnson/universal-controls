using UniversalUI;
using UniversalUI.Controls;
using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class ToggleSwitch_Examples
    {
        [Example("ToggleSwitch")]
        public static ToggleSwitch SimpleToggleSwitch() =>
            SimpleControls.SimpleControlsStatics.ToggleSwitch()
                .Width(40)
                .Height(30)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Red);

        [Example("ToggleSwitch with green thumb")]
        public static ToggleSwitch ToggleSwitchWithGreenThumb() =>
            ToggleSwitch()
                .Width(40)
                .Height(30d)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Green);
    }
}
