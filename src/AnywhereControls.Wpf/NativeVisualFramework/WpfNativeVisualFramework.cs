using System;
using System.Globalization;
using System.Windows.Media;
using Microsoft.Maui.Graphics;
using AnywhereControls.Controls;
using AnywhereControls.Wpf.Text;

namespace AnywhereControls.Wpf.NativeVisualFramework
{
    public class WpfNativeVisualFramework : IVisualFramework
    {
        public IDrawingContext CreateDrawingContext(IUIElement uiElement) => new WpfNativeDrawingContext();

        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes)
        {
            throw new NotImplementedException();
        }

        public RenderLayer CreateRenderLayer(IUIElement rootElement, object? arg1 = null, object? arg2 = null, object? arg3 = null) =>
            throw new NotImplementedException();

        public Size MeasureTextBlock(ITextBlock textBlock)
        {
            FormattedText? formattedText = ToFormattedText(textBlock);
            return new Size(formattedText.Width, formattedText.Height);
        }

        public static FormattedText ToFormattedText(ITextBlock textBlock)
        {
            Brush? brush = textBlock.Foreground.ToWpfBrush();

            var typeface = new Typeface(textBlock.FontFamily.ToWpfFontFamily(),
                textBlock.FontStyle.ToWpfFontStyle(),
                textBlock.FontWeight.ToWpfFontWeight(),
                textBlock.FontStretch.ToWpfFontStretch());

            return new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToWpfFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush,
                1.0); // TODO: Set this appropriately
        }
    }
}
