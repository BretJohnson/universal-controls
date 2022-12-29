using Microsoft.AspNetCore.Components.Rendering;

namespace Microsoft.StandardUI.SkiaVisualFramework.Blazor
{
    public class BlazorSkiaVisualFramework : SkiaVisualFramework
    {
        public override RenderLayer CreateRenderLayer(IUIElement rootElement,
            object? arg1 = null, object? arg2 = null, object? arg3 = null) =>
            new BlazorSkiaRenderLayer(rootElement, (RenderTreeBuilder) arg1!, (int) arg2!);
    }
}
