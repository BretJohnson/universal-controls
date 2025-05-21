using System.ComponentModel;
using UniversalUI;
using UniversalUI.Controls;
using UniversalUI.Media;
using UniversalUI.Shapes;
using static UniversalUI.UniversalUIStatics;

namespace AlohaKit.AnywhereControls
{
    [AnywhereControl]
    public abstract class ToggleSwitch : AnywhereControl
    {
        public ToggleSwitch()
        {
            UIElement.Width = 40;
            UIElement.Height = 30;
        }

        [DefaultValue(DefaultColor.White)]
        public abstract Color BackgroundColor { get; set; }

        [DefaultValue(DefaultColor.Black)]
        public abstract Color ThumbColor { get; set; }

        [DefaultValue(false)]
        public abstract bool IsOn { get; set; }

        [DefaultValue(true)]
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
