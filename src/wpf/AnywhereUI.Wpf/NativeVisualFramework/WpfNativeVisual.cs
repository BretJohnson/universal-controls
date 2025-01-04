using System.Windows.Media;
using AnywhereUI.VisualFramework;

namespace AnywhereUI.Wpf.NativeVisualFramework
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
