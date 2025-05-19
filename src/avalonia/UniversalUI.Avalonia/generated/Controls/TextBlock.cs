// This file is generated from ITextBlock.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AnywhereUIAvalonia.Media;
using AnywhereUI.Text;
using AnywhereUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class TextBlock : BuiltInUIElement, ITextBlock, IDrawable
    {
        public static readonly Avalonia.StyledProperty<Brush> ForegroundProperty = AvaloniaProperty.Register<TextBlock, Brush>(nameof(Foreground), null);
        public static readonly Avalonia.StyledProperty<string> TextProperty = AvaloniaProperty.Register<TextBlock, string>(nameof(Text), "");
        public static readonly Avalonia.StyledProperty<FontFamily> FontFamilyProperty = AvaloniaProperty.Register<TextBlock, FontFamily>(nameof(FontFamily), AnywhereControlsAvalonia.Text.FontFamilyExtensions.DefaultFontFamily);
        public static readonly Avalonia.StyledProperty<FontStyle> FontStyleProperty = AvaloniaProperty.Register<TextBlock, FontStyle>(nameof(FontStyle), FontStyle.Normal);
        public static readonly Avalonia.StyledProperty<FontWeight> FontWeightProperty = AvaloniaProperty.Register<TextBlock, FontWeight>(nameof(FontWeight), FontWeight.Default);
        public static readonly Avalonia.StyledProperty<double> FontSizeProperty = AvaloniaProperty.Register<TextBlock, double>(nameof(FontSize), 11.0);
        public static readonly Avalonia.StyledProperty<FontStretch> FontStretchProperty = AvaloniaProperty.Register<TextBlock, FontStretch>(nameof(FontStretch), FontStretch.Normal);
        public static readonly Avalonia.StyledProperty<TextAlignment> TextAlignmentProperty = AvaloniaProperty.Register<TextBlock, TextAlignment>(nameof(TextAlignment), TextAlignment.Left);
        
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
        protected override Avalonia.Size MeasureOverride(Avalonia.Size constraint) =>
            HostEnvironment.VisualFramework.MeasureTextBlock(this).ToAvaloniaSize();
    }
}
