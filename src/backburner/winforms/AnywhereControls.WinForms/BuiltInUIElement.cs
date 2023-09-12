using System;
using System.Windows.Forms;

namespace AnywhereControls.WinForms
{
    /// <summary>
    /// This is the base for predefined Standard UI controls. 
    /// </summary>
    public class BuiltInUIElement : Control, IUIElement
    {
        public double MinWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MaxWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HorizontalAlignment HorizontalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MinHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MaxHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public VerticalAlignment VerticalAlignment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public FlowDirection FlowDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Size DesiredSize => throw new NotImplementedException();

        public double ActualX => throw new NotImplementedException();

        public double ActualY => throw new NotImplementedException();

        public double ActualWidth => throw new NotImplementedException();

        public double ActualHeight => throw new NotImplementedException();

        bool IUIElement.Visible { get => Visible; set => Visible = value; }
        double IUIElement.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double IUIElement.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Arrange(Rect finalRect)
        {
            throw new NotImplementedException();
        }

        public object GetValue(IUIProperty property)
        {
            throw new NotImplementedException();
        }

        public void Measure(Size availableSize)
        {
            throw new NotImplementedException();
        }

        public object ReadLocalValue(IUIProperty property)
        {
            throw new NotImplementedException();
        }

        public void SetValue(IUIProperty property, object? value)
        {
            throw new NotImplementedException();
        }

        public void ClearValue(IUIProperty property)
        {
            throw new NotImplementedException();
        }

        protected virtual void Draw(IDrawingContext visualizer)
        {
        }
    }
}
