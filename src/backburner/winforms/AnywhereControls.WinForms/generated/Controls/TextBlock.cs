// This file is generated from ITextBlock.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;
using UniversalUI.WinForms.Media;
using UniversalUI.Text;
using UniversalUI.Controls;

namespace AnywhereControls.WinForms.Controls
{
    public class TextBlock : BuiltInUIElement, ITextBlock, IDrawable
    {
        public static readonly UIProperty ForegroundProperty = new UIProperty(nameof(Foreground), null);
        public static readonly UIProperty TextProperty = new UIProperty(nameof(Text), "");
        public static readonly UIProperty FontFamilyProperty = new UIProperty(nameof(FontFamily), "");
        public static readonly UIProperty FontStyleProperty = new UIProperty(nameof(FontStyle), FontStyle.Normal);
        public static readonly UIProperty FontWeightProperty = new UIProperty(nameof(FontWeight), FontWeight.Default);
        public static readonly UIProperty FontSizeProperty = new UIProperty(nameof(FontSize), 11.0);
        public static readonly UIProperty FontStretchProperty = new UIProperty(nameof(FontStretch), FontStretch.Normal);
        public static readonly UIProperty TextAlignmentProperty = new UIProperty(nameof(TextAlignment), TextAlignment.Left);
        
        public IBrush Foreground
        {
            get => (Brush) GetNonNullValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }
        
        public string Text
        {
            get => (string) GetNonNullValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public FontFamily FontFamily
        {
            get => (FontFamily) GetNonNullValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }
        
        public FontStyle FontStyle
        {
            get => (FontStyle) GetNonNullValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }
        
        public FontWeight FontWeight
        {
            get => (FontWeight) GetNonNullValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }
        
        public double FontSize
        {
            get => (double) GetNonNullValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        
        public FontStretch FontStretch
        {
            get => (FontStretch) GetNonNullValue(FontStretchProperty);
            set => SetValue(FontStretchProperty, value);
        }
        
        public TextAlignment TextAlignment
        {
            get => (TextAlignment) GetNonNullValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        
        public void Draw(IDrawingContext drawingContext) => drawingContext.DrawTextBlock(this);
    }
}
