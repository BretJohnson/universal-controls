using System;
using AnywhereControls.Controls;

namespace AnywhereControls.WinUI.NativeVisualFramework
{
    public class WinUINativeVisualFramework : IVisualFramework
    {
        public IDrawingContext CreateDrawingContext(IUIElement uiElement) => new WinUINativeDrawingContext(uiElement);

        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes)
        {
            throw new NotImplementedException();
        }

        public IVisualHostControl CreateHostControl(object? arg1 = null, object? arg2 = null, object? arg3 = null)
        {
            throw new NotImplementedException();
        }

        public Size MeasureTextBlock(ITextBlock textBlock)
        {
#if LATER
            FormattedText? formattedText = ToFormattedText(textBlock);
            return new Size(formattedText.Width, formattedText.Height);
#endif
            return Size.Default;
        }

#if LATER
        public static FormattedText ToFormattedText(ITextBlock textBlock)
        {
            Brush? brush = textBlock.Foreground.ToWinUIBrush();

            var typeface = new Typeface(textBlock.FontFamily.ToWinUIFontFamily(),
                textBlock.FontStyle.ToWinUIFontStyle(),
                textBlock.FontWeight.ToWinUIFontWeight(),
                textBlock.FontStretch.ToWinUIFontStretch());

            return new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToWinUIFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush,
                1.0); // TODO: Set this appropriately
        }
#endif
    }
}
