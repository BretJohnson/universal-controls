using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class CheckBox_Examples
    {
        [UIExample("UnChecked CheckBox")]
        public static ICheckBox UnCheckedCheckBox() =>
            CheckBox();

        [UIExample("Checked CheckBox")]
        public static ICheckBox CheckedCheckBox() =>
            CheckBox()
                .IsChecked(true);
    }
}
