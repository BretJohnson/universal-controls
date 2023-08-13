using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Microsoft.AspNetCore.Components.Rendering;

namespace AnywhereControls.SkiaVisualFramework
{
    public class BlazorSkiaRenderLayer : SkiaRenderLayer
    {
        public BlazorSkiaRenderLayer(IUIElement rootUIElement, RenderTreeBuilder builder, int index)
        {
            RootElement = rootUIElement;

            builder.OpenComponent<SKCanvasView>(index);
            builder.AddAttribute(index, "OnPaintSurface", (System.Action<SKPaintSurfaceEventArgs>)(OnPaintSurface));

            double width = RootElement.Width;
            double height = RootElement.Height;

            builder.AddAttribute(index + 1, "width", width);
            builder.AddAttribute(index + 2, "height", height);

            builder.CloseComponent();
        }

        private void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            RenderToCanvas(canvas);
        }
    }
}
