using System;
using AppKit;

namespace Microsoft.StandardUI.Mac
{
    /// <summary>
    /// This is the base for predefined Standard UI controls. 
    /// </summary>
    public class StandardUIElement : NSView, IUIElement
    {
        private BasicUIProperties _properties = new BasicUIProperties(true);

        void IUIElement.Measure(Size availableSize)
        {
            //Measure(availableSize.ToWpfSize());
        }

        void IUIElement.Arrange(Rect finalRect)
        {
            //Arrange(finalRect.ToNSRect());
        }

        Size IUIElement.DesiredSize => SizeExtensions.ToStandardUISize(IntrinsicContentSize);

        double IUIElement.ActualX => throw new NotImplementedException();

        double IUIElement.ActualY => throw new NotImplementedException();

        bool IUIElement.Visible
        {
            get => !Hidden;
            set => Hidden = !value;
        }

        double IUIElement.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.MinWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.MaxWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        HorizontalAlignment IUIElement.HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.MinHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.MaxHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        VerticalAlignment IUIElement.VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        FlowDirection IUIElement.FlowDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        double IUIElement.ActualWidth => throw new NotImplementedException();

        double IUIElement.ActualHeight => throw new NotImplementedException();

#if LATER
        protected override void OnRender(DrawingContext drawingContextWpf)
        {
            base.OnRender(drawingContextWpf);

            if (Visibility != Visibility.Visible)
                return;

            IVisualEnvironment visualEnvironment = StandardUIEnvironment.VisualEnvironment;

            Rect cullingRect = new Rect(0, 0, 200, 200);

            IVisual? visual;
            using (IDrawingContext drawingContext = visualEnvironment.CreateDrawingContext(this)) {
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
#endif

        public virtual void Draw(IDrawingContext visualizer)
        {
        }

        public object? GetValue(BasicUIProperty property) => _properties.GetValue(property);
        object? IUIObject.GetValue(IUIProperty property) => _properties.GetValue((BasicUIProperty)property);

        public object? ReadLocalValue(BasicUIProperty property) => _properties.ReadLocalValue(property);
        object? IUIObject.ReadLocalValue(IUIProperty property) => _properties.ReadLocalValue((BasicUIProperty)property);

        public void SetValue(BasicUIProperty property, object? value) => _properties.SetValue(property, value);
        void IUIObject.SetValue(IUIProperty property, object? value) => _properties.SetValue((BasicUIProperty)property, value);

        public void ClearValue(BasicUIProperty property) => _properties.ClearValue(property);
        void IUIObject.ClearValue(IUIProperty property) => _properties.ClearValue((BasicUIProperty) property);
    }
}
