using CommonUI;
using AnywhereUI.Controls;
using System;

namespace AnywhereControls.Blazor.NativeVisualFramework
{
    public class BlazorNativeVisualFramework : IVisualFramework
    {
        public BlazorNativeVisualFramework() =>
            throw new NotImplementedException("Eventually this will use the JavaScript bridge, but it's currently not supported. Use the Skia based Blazor VisualFramework instead.");

        public IDrawingContext CreateDrawingContext(IUIElement uiElement)
            => throw new NotImplementedException();

        public RenderLayer CreateRenderLayer(IUIElement rootElement, object? arg1 = null, object? arg2 = null, object? arg3 = null) =>
            throw new NotImplementedException();

        public Size MeasureTextBlock(ITextBlock textBlock) =>
            throw new NotImplementedException();

        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes) =>
            throw new NotImplementedException();

#if LATER
        private Canvas2DContext context;

        public BlazorVisualEnvironment(Canvas2DContext canvas)
        {
            context = canvas;
        }

        public IDrawingContext CreateDrawingContext(in Rect cullingRect)
        {
            return new BlazorDrawingContext(context);
        }

        public IVisualHostControl CreateHostControl(object? arg1 = null, object? arg2 = null, object? arg3 = null)
        {
            throw new NotImplementedException();
        }

        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes)
        {
            throw new NotImplementedException();
        }
#endif
    }
}
