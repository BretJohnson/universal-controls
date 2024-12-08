using System.ComponentModel;
using AnywhereUI;
using AnywhereUI.Controls;
using AnywhereUI.Media;
using AnywhereUI.Shapes;
using static AnywhereUI.AnywhereUIStatics;

namespace AlohaKit.AnywhereControls
{
    [AnywhereControl]
    public abstract class CheckBox : AnywhereControl
    {
        const int Radius = 4;

        public CheckBox()
        {
            UIElement.Width = 24;
            UIElement.Height = 24;
        }

        [DefaultValue(false)]
        public abstract bool IsChecked { get; set; }

        [DefaultValue(DefaultColor.White)]
        public abstract Color CheckedColor { get; set; }

        [DefaultValue(DefaultColor.Black)]
        public abstract Color UncheckedColor { get; set; }

        protected override IUIElement Build() =>
            Canvas()._
            (
                CheckBoxBackground(),
                BuildCheckBoxCheckIndicator()
            );

        IUIElement CheckBoxBackground()
        {
            if (IsChecked)
            {
                return Rectangle()
                    .Width(UIElement.Width)
                    .Height(UIElement.Height)
                    .RadiusX(Radius)
                    .RadiusY(Radius)
                    .StrokeThickness(0)
                    .Fill(SolidColorBrush(UncheckedColor));
            }
            else
            {
                return Rectangle()
                    .Width(UIElement.Width)
                    .Height(UIElement.Height)
                    .RadiusX(Radius)
                    .RadiusY(Radius)
                    .StrokeThickness(3)
                    .Stroke(SolidColorBrush(UncheckedColor))
                    .Fill(SolidColorBrush(Colors.Transparent));
            }
        }

        IUIElement BuildCheckBoxCheckIndicator()
        {
            if (IsChecked)
            {
                // TODO: Use a Path
                return Rectangle()
                    .Height(UIElement.Height / 2)
                    .Width(UIElement.Width / 2)
                    .RadiusX(Radius)
                    .RadiusY(Radius)
                    .Margin(new Thickness(UIElement.Height / 4, UIElement.Width / 4, 0, 0))
                    .Fill(SolidColorBrush(CheckedColor));
            }

            return Ellipse()
                .Fill(SolidColorBrush(Colors.Transparent));
        }
    }
}