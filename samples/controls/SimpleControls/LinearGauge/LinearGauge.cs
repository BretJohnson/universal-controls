using System.ComponentModel;
using AnywhereControls;
using AnywhereControls.Controls;
using AnywhereControls.Media;
using AnywhereControls.Shapes;
using static AnywhereControls.AnywhereControlsStatics;

namespace AlohaKit.StandardControls
{
    [AnywhereControl]
    public interface ILinearGauge : IAnywhereControl
    {
        [DefaultValue(DefaultColor.White)]
        public Color BackgroundColor { get; set; }

        [DefaultValue(DefaultColor.Black)]
        public Color ProgressColor { get; set; }

        [DefaultValue(0)]
        public int RangeStart { get; set; }

        [DefaultValue(100)]
        public int RangeEnd { get; set; }

        [DefaultValue(0)]
        public int Value { get; set; }
    }

    public abstract class LinearGauge : AnywhereControl, ILinearGauge
    {
        // TODO: Expose these properties 
        Color Stroke = Colors.Black;
        const float StrokeThickness = 2.0f;
        const float TicksWidth = 20.0f;
        const float CornerRadius = 20.0f;

        public LinearGauge()
        {
            UIElement.Width = 60;
            UIElement.Height = 200;
        }

        public abstract Color BackgroundColor { get; set; }
        public abstract Color ProgressColor { get; set; }
        public abstract int RangeStart { get; set; }
        public abstract int RangeEnd { get; set; }
        public abstract int Value { get; set; }


        protected override IUIElement Build()
        {
            int width = (int)UIElement.Width;
            int height = (int)UIElement.Height;

            ICanvas canvas =
                Canvas()
                    .Width(width)
                    .Height(height);

            // Background
            BuildLinearGaugeBackground(canvas);

            // Progress
            BuildLinearGaugeProgress(canvas);

            // Ticks
            BuildLinearGaugeTicks(canvas);

            return canvas;
        }

        void BuildLinearGaugeBackground(ICanvas canvas)
        {
            var linearGaugeBackground = Rectangle()
                .Width(UIElement.Width)
                .Height(UIElement.Height)
                .RadiusX(CornerRadius)
                .RadiusY(CornerRadius)
                .Fill(SolidColorBrush(BackgroundColor));

            canvas.Add(0, 0, linearGaugeBackground);
        }

        void BuildLinearGaugeProgress(ICanvas canvas)
        {
            int value = Value;

            if (value > RangeEnd)
                value = RangeEnd;

            if (value < RangeStart)
                value = RangeStart;

            var percentage = (double)value / RangeEnd;
            var progressHeight = UIElement.Height * percentage;
            var progressY = UIElement.Height - progressHeight;

            var rect = new Rect(
                0,
                progressY + StrokeThickness / 2,
                UIElement.Width,
                progressHeight - StrokeThickness);

            var linearGaugeProgress = Rectangle()
                .Margin(new Thickness(rect.X, rect.Y, 0, 0))
                .Width(rect.Width)
                .Height(rect.Height)
                .RadiusX(CornerRadius)
                .RadiusY(CornerRadius)
                .Fill(SolidColorBrush(ProgressColor));

            canvas.Add(0, 0, linearGaugeProgress);
        }

        void BuildLinearGaugeTicks(ICanvas canvas)
        {
            int steps = 10;

            for (int i = 0; i < steps; i++)
            {
                var stepScale = (double)i / steps;
                Point nextLine = new Point(TicksWidth, UIElement.Height * stepScale);

                double defaultTickWidth = 10.0d;
                double tickWidth = defaultTickWidth;

                if (i != 0)
                {
                    if (i == (steps / 2))
                        tickWidth = defaultTickWidth * 2;

                    var linearGaugeTick = Line()
                        .X1(nextLine.X)
                        .Y1(nextLine.Y)
                        .X2(nextLine.X + tickWidth)
                        .Y2(nextLine.Y)
                        .Stroke(Colors.Black);

                    canvas.Add(0, 0, linearGaugeTick);


                    var strValue = (int)(((double)RangeEnd / steps) * (steps - i));
                    Point stringPosition = new Point(nextLine.X - 16, nextLine.Y - 8);

                    var linearGaugeTextBlock = TextBlock()
                        .Margin(new Thickness(stringPosition.X, stringPosition.Y, 0, 0))
                        .Foreground(SolidColorBrush(Colors.Black))
                        .Text(strValue.ToString());

                    canvas.Add(0, 0, linearGaugeTextBlock);
                }
            }
        }
    }
}