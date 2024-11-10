using System.Globalization;
using AnywhereControls.Controls;
using Avalonia.Media;
using AnywhereControls;
using AnywhereControlsAvalonia.Text;

namespace AnywhereControlsAvalonia.NativeVisualFramework
{
    public class AvaloniaNativeVisualFramework : IVisualFramework
    {
        public IDrawingContext CreateDrawingContext(IUIElement uiElement) => new AvaloniaNativeDrawingContext();

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
            Brush? brush = textBlock.Foreground.ToAvaloniaBrush();

            var typeface = new Typeface(textBlock.FontFamily.ToAvaloniaFontFamily(),
                textBlock.FontStyle.ToAvaloniaFontStyle(),
                textBlock.FontWeight.ToAvaloniaFontWeight(),
                textBlock.FontStretch.ToAvaloniaFontStretch());

            return new FormattedText(
                textBlock.Text,
                CultureInfo.GetCultureInfo("en-us"),  // TODO: Set this appropriately
                textBlock.FlowDirection.ToAvaloniaFlowDirection(),
                typeface,
                textBlock.FontSize,  // TODO: Set this appropriately
                brush);
        }
    }
}
