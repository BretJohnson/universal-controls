using SkiaSharp;

namespace UniversalUI.SkiaVisualFramework
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
