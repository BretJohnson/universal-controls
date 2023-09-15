using AnywhereControls.Controls;
using System;

namespace AnywhereControls.Maui.NativeVisualFramework
{
    public class MauiNativeVisualFramework : IVisualFramework
    {
        readonly Microsoft.Maui.Graphics.ICanvas _canvas;

        public MauiNativeVisualFramework(Microsoft.Maui.Graphics.ICanvas canvas)
        {
            _canvas = canvas;
        }

        public IDrawingContext CreateDrawingContext(IUIElement uiElement) => new MauiNativeDrawingContext(_canvas);

        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes)
        {
            throw new NotImplementedException();
        }

        public RenderLayer CreateRenderLayer(IUIElement rootElement, object? arg1 = null, object? arg2 = null, object? arg3 = null) =>
            throw new NotImplementedException();

        public Size MeasureTextBlock(ITextBlock textBlock)
        {
            throw new NotImplementedException();
        }
    }
}