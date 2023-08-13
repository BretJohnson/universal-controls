using System;
using System.Windows.Media;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.Wpf
{
    /// <summary>
    /// This is the base for predefined Standard UI controls.
    /// </summary>
    public partial class BuiltInUIElement : System.Windows.FrameworkElement, IUIElement, ILogicalParent
    {
        private StandardUIFrameworkElementHelper _helper = new();

        protected override void OnRender(DrawingContext drawingContextWpf)
        {
            base.OnRender(drawingContextWpf);

            if (Visibility != System.Windows.Visibility.Visible)
                return;

            if (this is not IDrawable drawable)
                return;

            IVisualFramework visualFramework = HostEnvironment.VisualFramework;

            using (IDrawingContext drawingContext = visualFramework.CreateDrawingContext(this))
            {
                drawable.Draw(drawingContext);
                IVisual? visual = drawingContext.Close();

                if (visual != null)
                {
                    _helper.OnRender(visual, Width, Height, drawingContextWpf);
                }
            }
        }

        protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            InvalidateVisual();
        }

        public Rect Frame => throw new NotImplementedException();

        void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);
        void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);

        int IUIElement.VisualChildrenCount => 0;

        IUIElement IUIElement.GetVisualChild(int index) =>
            throw new IndexOutOfRangeException("UIElement has no children");
    }
}
