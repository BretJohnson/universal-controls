namespace UniversalUI
{
    public abstract class RenderLayer
    {
        public IUIElement? RootElement { get;  set; }

        protected void Render(IDrawingContext drawingContext)
        {
            IUIElement? content = RootElement;
            if (content == null)
                return;

            RenderVisualSubtree(content, drawingContext);
        }

        protected static void RenderVisualSubtree(IUIElement uiElement, IDrawingContext drawingContext)
        {
            if (uiElement is IDrawable drawable)
            {
                drawable.Draw(drawingContext);
            }

            int count = uiElement.VisualChildrenCount;
            for (int i = 0; i < count; i++)
            {
                IUIElement child = uiElement.GetVisualChild(i);

                drawingContext.PushTranslateTransform(child.Frame.X, child.Frame.Y);
                RenderVisualSubtree(child, drawingContext);
                drawingContext.Pop();
            }
        }
    }
}
