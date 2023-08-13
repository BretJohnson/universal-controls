using System.Windows.Media;

namespace Microsoft.StandardUI.Wpf.NativeVisualFramework
{
    public class WpfNativeVisual : IVisual
    {
        public DrawingGroup DrawingGroup { get; }

        public WpfNativeVisual(DrawingGroup drawingGroup)
        {
            DrawingGroup = drawingGroup;
        }

        public object NativeVisual => DrawingGroup;
    }
}
