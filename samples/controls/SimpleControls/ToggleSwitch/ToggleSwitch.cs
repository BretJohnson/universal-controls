using System.ComponentModel;
using Microsoft.Maui.Graphics;
using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace AlohaKit.StandardControls
{
    [StandardControl]
    public interface IToggleSwitch : IStandardControl
    {
        [DefaultValue(DefaultColor.White)]
        public Color BackgroundColor { get; set; }

        [DefaultValue(DefaultColor.Black)]
        public Color ThumbColor { get; set; }

        [DefaultValue(false)]
        public bool IsOn { get; set; }

        [DefaultValue(true)]
        public bool HasShadow { get; set; }
    }

    public class ToggleSwitch : StandardControl<IToggleSwitch>
    {
        public ToggleSwitch(IToggleSwitch control) : base(control)
        {
            Control.Width = 40;
            Control.Height = 30;
        }

        public override IUIElement? Build() =>
            Canvas()._(
                Rectangle()
                    .Width(Control.Width)
                    .Height(Control.Height)
                    .RadiusX(16)
                    .RadiusY(16)
                    .Fill(SolidColorBrush(Control.BackgroundColor)),

                Ellipse()
                    .CanvasLeft(Control.IsOn ? 35 : 15)
                    .CanvasTop(3)
                    .Width(24)
                    .Height(24)
                    .Fill(SolidColorBrush(Control.ThumbColor))
            );
    }
}
