namespace AnywhereUI.Wpf
{
#if false
    public partial class WpfAnywhereControl : System.Windows.Controls.Control, IAnywhereControl, IAnywhereControlEnvironmentPeer, ILogicalParent
    {
        private AnywhereControl? _anywhereControl;
        private IUIElement? _buildContent;
        private bool _invalid = true;

        public WpfAnywhereControl()
        {
            if (!HostEnvironment.IsInitialized)
            {
                WpfHostFramework.Init(new WpfNativeVisualFramework());
            }
        }

        protected void InitImplementation(AnywhereControl anywhereControl)
        {
            _anywhereControl = anywhereControl;
        }

        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            if (_invalid)
            {
                Rebuild();
                _invalid = false;
            }

            _anywhereControl!.Measure(new Size(constraint.Width, constraint.Height));
            return _anywhereControl.DesiredSize.ToWpfSize();
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            _anywhereControl!.Arrange(new Rect(0, 0, arrangeSize.Width, arrangeSize.Height));
            return arrangeSize;
        }

        IUIElement? IAnywhereControlEnvironmentPeer.BuildContent => _buildContent;

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

            _buildContent = _anywhereControl!.Build();

            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement = _buildContent.ToWpfUIElement();
                AddVisualChild(wpfUIElement);
                AddLogicalChild(wpfUIElement);
            }
        }
    }
#endif
}
