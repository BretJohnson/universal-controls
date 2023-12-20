using System.ComponentModel;
using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace AlohaKit.AnywhereControls
{
    [AnywhereControl]
    public interface IToggleSwitch : IAnywhereControl
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

    public abstract class ToggleSwitch : AnywhereControl, IToggleSwitch
    {
        public ToggleSwitch()
        {
            UIElement.Width = 40;
            UIElement.Height = 30;
        }

        public abstract Color BackgroundColor { get; set; }
        public abstract Color ThumbColor { get; set; }
        public abstract bool IsOn { get; set; }
        public abstract bool HasShadow { get; set; }

        protected override IUIElement Build() =>
            Canvas()._
            (
                Rectangle()
                    .Width(UIElement.Width)
                    .Height(UIElement.Height)
                    .RadiusX(16)
                    .RadiusY(16)
                    .Fill(SolidColorBrush(BackgroundColor)),

                Ellipse()
                    .CanvasLeft(IsOn ? 35 : 15)
                    .CanvasTop(3)
                    .Width(24)
                    .Height(24)
                    .Fill(SolidColorBrush(ThumbColor))
            );
    }
}
