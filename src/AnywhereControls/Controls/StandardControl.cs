using System;
using Microsoft.Maui.Graphics;

namespace Microsoft.StandardUI.Controls
{
    public abstract class StandardControl
    {
        IStandardControlEnvironmentPeer _environmentPeer;

        public StandardControl(IStandardControlEnvironmentPeer environmentPeer)
        {
            _environmentPeer = environmentPeer;
        }

        /// <summary>
        /// Create the contents of the control.
        /// </summary>
        /// <returns>control contents, or null if all content is drawn via Render</returns>
        public virtual IUIElement? Build() => null;

        /// <summary>
        /// This method can be overridden to add further graphical elements (not previously defined in a logical tree) to a control.
        /// The drawing instructions here aren't displayed immediately; instead they captured in an IVisual, shown later as part
        /// of rendering the control.
        ///
        /// There are two basic ways to create output for a control - create children for it (including shape primitives)
        /// or create an IVisual by drawing to the IDrawingContext here. You can also combine approaches. In general, creating
        /// children is more flexible, as those children can get input events and be replaced via templates. Each child will
        /// also show up in UI hierarchy inspector tooling (like the Live Visual Tree in Visual Studio) as a separate element.
        /// On the other hand, drawing to the IDrawingContext is lighter weight - all drawing instructions are combined into a
        /// single IVisual, which in some cases is even stored on the GPU.
        /// </summary>
        /// <param name="drawingContext">drawing context that should draw to</param>
        public virtual void Render(IDrawingContext drawingContext) { }

        public Size DesiredSize { get; private set; }

        public void Measure(Size availableSize)
        {
            Size desiredSize = MeasureOverride(availableSize.Width, availableSize.Height);

            //enforce that MeasureCore can not return PositiveInfinity size even if given Infinte availabel size.
            //Note: NegativeInfinity can not be returned by definition of Size structure.
            if (double.IsPositiveInfinity(desiredSize.Width) || double.IsPositiveInfinity(desiredSize.Height))
                throw new InvalidOperationException($"Layout measurement override of element '{GetType().FullName}' should not return PositiveInfinity as its DesiredSize, even if Infinity is passed in as available size.");

            //enforce that MeasureCore cannot return NaN size.
            if (double.IsNaN(desiredSize.Width) || double.IsNaN(desiredSize.Height))
                throw new InvalidOperationException($"Layout measurement override of element '{GetType().FullName}' should not return NaN values as its DesiredSize.");

            DesiredSize = desiredSize;
        }

        public void Arrange(Rect finalRect)
        {
            ArrangeOverride(new Size(finalRect.Width, finalRect.Height));
        }

        protected virtual Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            IUIElement? buildContent = _environmentPeer.BuildContent;

            // By default, return the size of the content
            if (buildContent != null)
            {
                buildContent.Measure(widthConstraint, heightConstraint);
                return buildContent.DesiredSize;
            }

            return new Size(0.0, 0.0);
        }

        protected virtual Size ArrangeOverride(Size finalSize)
        {
            IUIElement? buildContent = _environmentPeer.BuildContent;

            // By default, give all the space to the content
            if (buildContent != null)
            {
                Rect finalRect = new Rect(0, 0, finalSize.Width, finalSize.Height);
                buildContent.Arrange(finalRect);
            }

            return finalSize;
        }
    }

    public abstract class StandardControl<T> : StandardControl where T : IStandardControl
    {
        public T Control { get; }

        public StandardControl(T control) : base((IStandardControlEnvironmentPeer)control)
        {
            Control = control;
        }
    }
}
