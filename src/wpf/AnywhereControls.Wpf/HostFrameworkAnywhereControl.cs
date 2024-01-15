using System;
using AnywhereControls.Wpf;
using AnywhereControls.Wpf.NativeVisualFramework;

namespace AnywhereControls.Controls
{
    // The rest of the implementation of this class is in HostFrameworkAnywhereControlGenerated.cs
    public abstract partial class HostFrameworkAnywhereControl : System.Windows.Controls.Control, IAnywhereControl, ILogicalParent
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

        protected abstract IUIElement? Build();
    }
}
