using AnywhereUI;
using Avalonia.Media;

namespace AnywhereControlsAvalonia.NativeVisualFramework
{
    public class AvaloniaNativeVisual : IVisual
    {
        public DrawingGroup DrawingGroup { get; }

        public AvaloniaNativeVisual(DrawingGroup drawingGroup)
        {
            DrawingGroup = drawingGroup;
        }

        public object NativeVisual => DrawingGroup;
    }
}
