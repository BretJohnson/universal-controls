using System;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Wpf.NativeVisualFramework;

namespace Microsoft.StandardUI.Wpf
{
    public partial class WpfStandardControl : System.Windows.Controls.Control, IStandardControl, IStandardControlEnvironmentPeer, ILogicalParent
    {
        private StandardControl? _standardControl;
        private IUIElement? _buildContent;
        private bool _invalid = true;

        public WpfStandardControl()
        {
            if (!HostEnvironment.IsInitialized)
            {
                WpfHostFramework.Init(new WpfNativeVisualFramework());
            }
        }

        protected void InitImplementation(StandardControl standardControl)
        {
            _standardControl = standardControl;
        }

        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            if (_invalid)
            {
                Rebuild();
                _invalid = false;
            }

            _standardControl!.Measure(new Size(constraint.Width, constraint.Height));
            return _standardControl.DesiredSize.ToWpfSize();
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            _standardControl!.Arrange(new Rect(0, 0, arrangeSize.Width, arrangeSize.Height));
            return arrangeSize;
        }

        IUIElement? IStandardControlEnvironmentPeer.BuildContent => _buildContent;

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

            _buildContent = _standardControl!.Build();

            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement = _buildContent.ToWpfUIElement();
                AddVisualChild(wpfUIElement);
                AddLogicalChild(wpfUIElement);
            }
        }
    }
}
