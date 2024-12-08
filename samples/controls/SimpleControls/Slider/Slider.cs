using AnywhereUI.Controls;
using AnywhereUI;
using System.ComponentModel;
using static AnywhereUI.AnywhereUIStatics;
using AnywhereUI.Shapes;

namespace AlohaKit.AnywhereControls
{
    [AnywhereControl]
    public abstract class Slider : AnywhereControl
    {
        const float TrackSize = 2f;

        public Slider()
        {
            UIElement.Width = 120;
            UIElement.Height = 20;
        }

        [DefaultValue(0d)]
        public abstract double Minimum { get; set; }

        [DefaultValue(10d)]
        public abstract double Maximum { get; set; }

        [DefaultValue(0d)]
        public abstract double Value { get; set; }

        [DefaultValue(DefaultColor.LightGray)]
        public abstract Color MinimumColor { get; set; }

        [DefaultValue(DefaultColor.Gray)]
        public abstract Color MaximumColor { get; set; }

        [DefaultValue(DefaultColor.DarkGray)]
        public abstract Color ThumbColor { get; set; }

        protected override IUIElement Build() =>
            Canvas()
                .Width(UIElement.Width)
                .Height(UIElement.Height)
                ._(
                    SliderTrack(),
                    SliderProgress(),
                    SliderThumb()
                );

        IUIElement SliderTrack()
        {
            var height = TrackSize;
            var y = (float)((UIElement.Height - height) / 2);

            return Rectangle()
                .Width(UIElement.Width)
                .Height(height)
                .Margin(new Thickness(0, y, 0, 0))
                .Fill(SolidColorBrush(MinimumColor));
        }

        IUIElement SliderProgress()
        {
            var value = (Value / Maximum - Minimum).Clamp(0, 1);

            var width = (float)(UIElement.Width * value);
            var height = TrackSize;

            var x = 0;
            var y = (float)((UIElement.Height - height) / 2);

            return Rectangle()
                .Width(width)
                .Height(height)
                .Margin(new Thickness(x, y, 0, 0))
                .Fill(SolidColorBrush(MaximumColor));
        }

        IUIElement SliderThumb()
        {
            const double ThumbSize = 18d;

            var value = (Value / Maximum - Minimum).Clamp(0, 1);

            var x = (float)((UIElement.Width * value) - (ThumbSize / 2));

            if (x <= 0)
                x = 0;

            if (x >= UIElement.Width - ThumbSize)
                x = (float)(UIElement.Width - ThumbSize);

            var y = (float)((UIElement.Height - ThumbSize) / 2);

            return Ellipse()
                .Width((ThumbSize))
                .Height(ThumbSize)
                .Margin(new Thickness(x, y, 0, 0))
                .Fill(SolidColorBrush(ThumbColor));
        }
    }
}