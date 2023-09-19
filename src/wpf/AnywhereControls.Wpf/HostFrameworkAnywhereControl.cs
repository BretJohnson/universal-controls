using System;
using AnywhereControls.Wpf;
using AnywhereControls.Wpf.NativeVisualFramework;
using Visibility = System.Windows.Visibility;

namespace AnywhereControls.Controls
{
    public abstract class HostFrameworkAnywhereControl : System.Windows.Controls.Control, IAnywhereControl, ILogicalParent
    {
        protected IUIElement? _buildContent;
        private bool _invalid = true;

        public HostFrameworkAnywhereControl()
        {
            if (!HostEnvironment.IsInitialized)
            {
                WpfHostFramework.Init(new WpfNativeVisualFramework());
            }
        }

        protected IUIElement? BuildContent => _buildContent;

        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            if (_invalid)
            {
                Rebuild();
                _invalid = false;
            }

            ((IUIElement) this).Measure(constraint.ToAnywhereControlsSize());
            return ((IUIElement)this).DesiredSize.ToWpfSize();
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            ((IUIElement) this).Arrange(new Rect(0, 0, arrangeSize.Width, arrangeSize.Height));
            return arrangeSize;
        }

        int IUIElement.VisualChildrenCount => _buildContent != null ? 1 : 0;

        IUIElement IUIElement.GetVisualChild(int index)
        {
            if (_buildContent == null)
                throw new ArgumentOutOfRangeException("index", index, "Control returned null from build");
            if (index != 0)
                throw new ArgumentOutOfRangeException("index", index, "Index out of range; control only has a single visual child.");

            return _buildContent;
        }

        public Rect Frame => throw new NotImplementedException();

        void ILogicalParent.AddLogicalChild(object child) => this.AddLogicalChild(child);

        void ILogicalParent.RemoveLogicalChild(object child) => this.RemoveLogicalChild(child);

        private void Rebuild()
        {
            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement = _buildContent.ToWpfUIElement();
                RemoveVisualChild(wpfUIElement);
                RemoveLogicalChild(wpfUIElement);
                _buildContent = null;
            }

            _buildContent = this.Build();

            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement = _buildContent.ToWpfUIElement();
                AddVisualChild(wpfUIElement);
                AddLogicalChild(wpfUIElement);
            }
        }

        void IUIElement.Measure(Size desiredSize) =>
            Measure(new System.Windows.Size(desiredSize.Width, desiredSize.Height));
        void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());
        Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

        double IUIElement.ActualX => throw new System.NotImplementedException();
        double IUIElement.ActualY => throw new System.NotImplementedException();

        Thickness IUIElement.Margin
        {
            get => Margin.ToAnywhereControlsThickness();
            set => Margin = value.ToWpfThickness();
        }

        HorizontalAlignment IUIElement.HorizontalAlignment
        {
            get => HorizontalAlignment.ToStandardUIHorizontalAlignment();
            set => HorizontalAlignment = value.ToWpfHorizontalAlignment();
        }

        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => VerticalAlignment.ToAnywhereControlsVerticalAlignment();
            set => VerticalAlignment = value.ToWpfVerticalAlignment();
        }

        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToWpfFlowDirection();
        }

        bool IUIElement.Visible
        {
            get => Visibility != Visibility.Collapsed;
            set => Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        double IUIElement.Width
        {
            get => Width;
            set => Width = value;
        }

        double IUIElement.MinWidth
        {
            get => MinWidth;
            set => MinWidth = value;
        }

        double IUIElement.MaxWidth
        {
            get => MaxWidth;
            set => MaxWidth = value;
        }

        double IUIElement.Height
        {
            get => Height;
            set => Height = value;
        }

        double IUIElement.MinHeight
        {
            get => MinHeight;
            set => MinHeight = value;
        }

        double IUIElement.MaxHeight
        {
            get => MaxHeight;
            set => MaxHeight = value;
        }

        double IUIElement.ActualWidth => ActualWidth;
        double IUIElement.ActualHeight => ActualHeight;

        object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
        void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
        void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);

        protected override int VisualChildrenCount => 
            ((IUIElement)this).VisualChildrenCount;
        protected override System.Windows.Media.Visual GetVisualChild(int index) =>
            ((IUIElement)this).GetVisualChild(index).ToWpfUIElement();

        protected abstract IUIElement? Build();
    }
}
