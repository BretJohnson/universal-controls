using Microsoft.ComponentModelEx;
using CommonUI;
using AnywhereControls;
using AnywhereControls.Controls;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.StandardControls
{
    public class ToggleSwitch_Examples
    {
        [UIExample("ToggleSwitch")]
        public static IToggleSwitch SimpleToggleSwitch() =>
            ToggleSwitch()
                .Width(40)
                .Height(30)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Red);

        [UIExample("ToggleSwitch with green thumb")]
        public static IToggleSwitch ToggleSwitchWithGreenThumb() =>
            ToggleSwitch()
                .Width(40)
                .Height(30d)
                .BackgroundColor(Colors.Gray)
                .ThumbColor(Colors.Green);
    }
}
