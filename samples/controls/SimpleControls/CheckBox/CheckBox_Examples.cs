using ExampleFramework;
using static SimpleControls.SimpleControlsStatics;

namespace AlohaKit.AnywhereControls
{
    public class CheckBox_Examples
    {
        [Example("UnChecked CheckBox")]
        public static CheckBox UnCheckedCheckBox() =>
            CheckBox();

        [Example("Checked CheckBox")]
        public static CheckBox CheckedCheckBox() =>
            CheckBox()
                .IsChecked(true);
    }
}
