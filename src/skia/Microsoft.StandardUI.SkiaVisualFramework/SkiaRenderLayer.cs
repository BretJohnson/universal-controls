using SkiaSharp;

namespace Microsoft.StandardUI.SkiaVisualFramework
{
    public class SkiaRenderLayer : RenderLayer
    {
        public void RenderToCanvas(SKCanvas canvas)
        {
            SkiaDrawingContext skiaDrawingContext = new SkiaDrawingContext(canvas);
            Render(skiaDrawingContext);
        }
    }
}
