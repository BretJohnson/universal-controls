using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class CheckBox_Examples
    {
        [UIExample("UnChecked CheckBox")]
        public static CheckBox UnCheckedCheckBox() =>
            CheckBox();

        [UIExample("Checked CheckBox")]
        public static CheckBox CheckedCheckBox() =>
            CheckBox()
                .IsChecked(true);
    }
}
