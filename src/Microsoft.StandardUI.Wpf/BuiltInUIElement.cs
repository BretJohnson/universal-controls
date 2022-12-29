using System;
using System.Windows;
using System.Windows.Media;

namespace Microsoft.StandardUI.Wpf
{
    /// <summary>
    /// This is the base for predefined Standard UI controls.
    /// </summary>
    public partial class BuiltInUIElement : FrameworkElement, IUIElement, ILogicalParent
    {
        private StandardUIFrameworkElementHelper _helper = new();

        protected override void OnRender(DrawingContext drawingContextWpf)
        {
            base.OnRender(drawingContextWpf);

            if (Visibility != Visibility.Visible)
                return;

            IVisualFramework visualFramework = HostEnvironment.VisualFramework;

            Rect cullingRect = new Rect(0, 0, 200, 200);

            IVisual? visual;
            using (IDrawingContext drawingContext = visualFramework.CreateDrawingContext(this))
            {
                Draw(drawingContext);
                visual = drawingContext.Close();
            }

            if (visual != null)
            {
                _helper.OnRender(visual, Width, Height, drawingContextWpf);
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            InvalidateVisual();
        }

        public virtual void Draw(IDrawingContext visualizer)
        {
        }

        public Rect Frame => throw new NotImplementedException();

        void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);
        void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);

        int IUIElement.VisualChildrenCount => 0;

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");
    }
}
