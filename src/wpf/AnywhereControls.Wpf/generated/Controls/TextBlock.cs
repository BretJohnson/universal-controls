// This file is generated from ITextBlock.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using AnywhereControls.Wpf.Media;
using AnywhereControls.Text;
using AnywhereControls.Controls;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Controls
{
    public class TextBlock : BuiltInUIElement, ITextBlock, IDrawable
    {
        public static readonly DependencyProperty ForegroundProperty = PropertyUtils.Register(nameof(Foreground), typeof(Brush), typeof(TextBlock), null);
        public static readonly DependencyProperty TextProperty = PropertyUtils.Register(nameof(Text), typeof(string), typeof(TextBlock), "");
        public static readonly DependencyProperty FontFamilyProperty = PropertyUtils.Register(nameof(FontFamily), typeof(FontFamily), typeof(TextBlock), Wpf.Text.FontFamilyExtensions.DefaultFontFamily);
        public static readonly DependencyProperty FontStyleProperty = PropertyUtils.Register(nameof(FontStyle), typeof(FontStyle), typeof(TextBlock), FontStyle.Normal);
        public static readonly DependencyProperty FontWeightProperty = PropertyUtils.Register(nameof(FontWeight), typeof(FontWeight), typeof(TextBlock), FontWeight.Default);
        public static readonly DependencyProperty FontSizeProperty = PropertyUtils.Register(nameof(FontSize), typeof(double), typeof(TextBlock), 11.0);
        public static readonly DependencyProperty FontStretchProperty = PropertyUtils.Register(nameof(FontStretch), typeof(FontStretch), typeof(TextBlock), FontStretch.Normal);
        public static readonly DependencyProperty TextAlignmentProperty = PropertyUtils.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(TextBlock), TextAlignment.Left);
        
        public Brush Foreground
        {
            get => (Brush) GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }
        IBrush ITextBlock.Foreground
        {
            get => Foreground;
            set => Foreground = (Brush) value;
        }
        
        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public FontFamily FontFamily
        {
            get => (FontFamily) GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }
        
        public FontStyle FontStyle
        {
            get => (FontStyle) GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }
        
        public FontWeight FontWeight
        {
            get => (FontWeight) GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }
        
        public double FontSize
        {
            get => (double) GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        
        public FontStretch FontStretch
        {
            get => (FontStretch) GetValue(FontStretchProperty);
            set => SetValue(FontStretchProperty, value);
        }
        
        public TextAlignment TextAlignment
        {
            get => (TextAlignment) GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawTextBlock(this);
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>
            HostEnvironment.VisualFramework.MeasureTextBlock(this).ToWpfSize();
    }
}
