using AnywhereControls.Controls;
using AnywhereControls;
using System.ComponentModel;
using static AnywhereControls.AnywhereControlsStatics;
using AnywhereControls.Shapes;

namespace AlohaKit.StandardControls
{
    [AnywhereControl]
    public interface ISlider : IAnywhereControl
    {
        [DefaultValue(0d)]
        public double Minimum { get; set; }

        [DefaultValue(10d)]
        public double Maximum { get; set; }

        [DefaultValue(0d)]
        public double Value { get; set; }

        [DefaultValue(DefaultColor.LightGray)]
        public Color MinimumColor { get; set; }

        [DefaultValue(DefaultColor.Gray)]
        public Color MaximumColor { get; set; }

        [DefaultValue(DefaultColor.DarkGray)]
        public Color ThumbColor { get; set; }
    }

    public abstract class Slider : AnywhereControl, ISlider
    {
        const float TrackSize = 2f;

        public Slider()
        {
            UIElement.Width = 120;
            UIElement.Height = 20;
        }

        public abstract double Minimum { get; set; }
        public abstract double Maximum { get; set; }
        public abstract double Value { get; set; }
        public abstract Color MinimumColor { get; set; }
        public abstract Color MaximumColor { get; set; }
        public abstract Color ThumbColor { get; set; }

        protected override IUIElement Build()
        {
            int width = (int)UIElement.Width;
            int height = (int)UIElement.Height;

            ICanvas canvas =
                Canvas()
                    .Width(width)
                    .Height(height);

            // Track
            BuildSliderTrack(canvas);

            // Progress
            BuildSliderProgress(canvas);

            // Thumb
            BuildSliderThumb(canvas);

            return canvas;
        }

        void BuildSliderTrack(ICanvas canvas)
        {
            var height = TrackSize;
            var y = (float)((UIElement.Height - height) / 2);

            var sliderTrack = Rectangle()
                .Width(UIElement.Width)
                .Height(height)
                .Margin(new Thickness(0, y, 0, 0))
                .Fill(SolidColorBrush(MinimumColor));

            canvas.Add(0, 0, sliderTrack);
        }

        void BuildSliderProgress(ICanvas canvas)
        {
            var value = (Value / Maximum - Minimum).Clamp(0, 1);

            var width = (float)(UIElement.Width * value);
            var height = TrackSize;

            var x = 0;
            var y = (float)((UIElement.Height - height) / 2);

            var sliderProgress = Rectangle()
                .Width(width)
                .Height(height)
                .Margin(new Thickness(x, y, 0, 0))
                .Fill(SolidColorBrush(MaximumColor));

            canvas.Add(0, 0, sliderProgress);
        }

        void BuildSliderThumb(ICanvas canvas)
        {
            const double ThumbSize = 18d;

            var value = (Value / Maximum - Minimum).Clamp(0, 1);

            var x = (float)((UIElement.Width * value) - (ThumbSize / 2));

            if (x <= 0)
                x = 0;

            if (x >= UIElement.Width - ThumbSize)
                x = (float)(UIElement.Width - ThumbSize);

            var y = (float)((UIElement.Height - ThumbSize) / 2);

            var sliderThumb = Ellipse()
                .Width((ThumbSize))
                .Height(ThumbSize)
                .Margin(new Thickness(x, y, 0, 0))
                .Fill(SolidColorBrush(ThumbColor));

            canvas.Add(0, 0, sliderThumb);
        }
    }
}