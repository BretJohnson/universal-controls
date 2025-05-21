using UniversalUI;
using UniversalUI.Controls;
using UniversalUI.Media;
using static AnywhereControls.FactoryStatics;

namespace TemplateStandardUI.Controls
{
    // TODO: Add Indeterminate State
    public class ProgressBar : StandardUIControl
    {
        const string ElementBackground = "PART_Background";
        const string ElementProgress = "PART_Progress";
        const string ElementText = "PART_Text";

        IBorder _background;
        IBorder _progress;
        ITextBlock _text;

        public ProgressBar()
        {

        }

        public static readonly IUIProperty ProgressProperty =
            RegisterUIProperty(nameof(Progress), typeof(double), typeof(ProgressBar), UIPropertyMetdata(0.0d, OnValueChanged));

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set { SetValue(ProgressProperty, value); }
        }

        static void OnValueChanged(IUIPropertyObject bindable, IUIPropertyChangedEventArgs e)
        {
            (bindable as ProgressBar)?.UpdateProgress();
        }

        public static readonly IUIProperty BackgroundColorProperty =
            RegisterUIProperty(nameof(BackgroundColor), typeof(Color), typeof(ProgressBar), UIPropertyMetdata(Color.Default));

        public Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly IUIProperty ProgressColorProperty =
            RegisterUIProperty(nameof(ProgressColor), typeof(Color), typeof(ProgressBar), UIPropertyMetdata(Color.Default));

        public Color ProgressColor
        {
            get => (Color)GetValue(ProgressColorProperty);
            set { SetValue(ProgressColorProperty, value); }
        }

        public static readonly IUIProperty BorderColorProperty =
            RegisterUIProperty(nameof(BorderColor), typeof(Color), typeof(ProgressBar), UIPropertyMetdata(Color.Default));

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly IUIProperty TextProperty =
            RegisterUIProperty(nameof(Text), typeof(string), typeof(ProgressBar), UIPropertyMetdata(string.Empty));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }

        public static readonly IUIProperty TextColorProperty =
            RegisterUIProperty(nameof(TextColor), typeof(Color), typeof(ProgressBar), UIPropertyMetdata(Color.Default));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly IUIProperty CornerRadiusProperty =
            RegisterUIProperty(nameof(CornerRadius), typeof(double), typeof(ProgressBar), UIPropertyMetdata(0.0d));

        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set { SetValue(CornerRadiusProperty, value); }
        }

        internal static readonly IUIProperty PercentagePropertyKey =
            RegisterUIProperty(nameof(Percentage), typeof(double), typeof(ProgressBar), UIPropertyMetdata(0.0d));

        public static readonly IUIProperty PercentageProperty = PercentagePropertyKey.IDependencyProperty;

        public double Percentage
        {
            get => (double)GetValue(PercentageProperty);
            private set
            {
                SetValue(PercentagePropertyKey, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _background = GetTemplateChild(ElementBackground) as IBorder;
            _progress = GetTemplateChild(ElementProgress) as IBorder;
            _text = GetTemplateChild(ElementText) as IText;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            UpdateProgress();
        }

        void UpdateProgress()
        {
            var percentage = _progress.Width = Math.Floor(_background.Width * Progress);

            var textTranslationX = percentage / 2 - _text.ActualX / 2;

            if (textTranslationX <= 0)
            {
                textTranslationX = _background.ActualWidth / 2 - _text.ActualX;
                _text.Foreground = SolidColorBrush().Color(TextColor);
            }
            else
            {
                textTranslationX = percentage / 2 - _text.ActualX;
                _text.Foreground = SolidColorBrush().Color(BackgroundColor);
            }

            _text.TranslationX = textTranslationX;

            Percentage = Math.Round(Progress * 100, 1);
        }
    }
}