using System;
using CommonUI;
using AnywhereControls.Controls;

namespace AnywhereControls
{
    /// <summary>
    /// The visual environment is responsible for drawing things on the screen, or to a bitmap,
    /// abstracting a retained mode graphics system.
    /// 
    /// There are a few steps in the rendering process:
    /// 1. An IVisualizer turns platform independent shapes/graphics primitives into a platform
    /// specific optimized representation of those primitives, an IVisual.
    /// 
    /// 2. Multiple IVisuals may be combined together, to do compositing. 
    /// 
    /// 3. An IVisual can be rendered to the screen by hosting it in an RenderLayer
    /// (which for example hosts OpenGL content for a Skia based visual environment).
    /// For best performance, IVisuals can be composited together when possible to minimize the
    /// number of host controls. An IVisual can also be rendered to a bitmap with RenderToBuffer.
    /// </summary>
    public interface IVisualFramework
    {
        IDrawingContext CreateDrawingContext(IUIElement uiElement);

        /// <summary>
        /// Render the visual to the specified bitmap memory buffer.
        /// </summary>
        /// <param name="visual">visual to render</param>
        /// <param name="pixels">buffer data</param>
        /// <param name="width">width of the bitmap, in pixels</param>
        /// <param name="height">height of the bitmap, in pixels</param>
        /// <param name="rowBytes">number of bytes per row in the buffer</param>
        public void RenderToBuffer(IVisual visual, IntPtr pixels, int width, int height, int rowBytes);

        /// <summary>
        /// Create a platform specific control that can be used to render IVisual graphics. For example,
        /// for a Skia based visual environment, the control hosts OpenGL content.
        /// </summary>
        /// <param name="arg1">environment/platform specific argument</param>
        /// <param name="arg2">environment/platform specific argument</param>
        /// <param name="arg3">environment/platform specific argument</param>
        /// <returns>visual host control</returns>
        public RenderLayer CreateRenderLayer(IUIElement rootElement,
            object? arg1 = null, object? arg2 = null, object? arg3 = null);

        public Size MeasureTextBlock(ITextBlock textBlock);
    }
}
