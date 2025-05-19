namespace AnywhereUI.Maui.NativeVisualFramework
{
    public class MauiNativeVisual : IVisual
    {
        public Microsoft.Maui.Graphics.ICanvas Canvas { get; }

        public MauiNativeVisual(Microsoft.Maui.Graphics.ICanvas canvas)
        {
            Canvas = canvas;
        }

        public object NativeVisual => Canvas;
    }
}