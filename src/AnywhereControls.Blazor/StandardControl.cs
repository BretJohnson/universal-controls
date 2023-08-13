using System;
using AnywhereControls.Controls;

namespace AnywhereControls.Blazor.NativeVisualFramework
{
    public partial class StandardControl : UIElement, IStandardControl, IStandardControlEnvironmentPeer
    {
        private AnywhereControls.Controls.StandardControl? _implementation;
        private IUIElement? _buildContent;
        private bool _invalid = true;

        public StandardControl()
        {
            if (!HostEnvironment.IsInitialized)
                BlazorHostFramework.Init(new BlazorNativeVisualFramework());
        }

        protected void InitImplementation(AnywhereControls.Controls.StandardControl implementation)
        {
            _implementation = implementation;
        }

        IUIElement? IStandardControlEnvironmentPeer.BuildContent => _buildContent;

        private void Rebuild()
        {
#if LATER
            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement =_buildContent.ToWpfUIElement();
                RemoveVisualChild(wpfUIElement);
                RemoveLogicalChild(wpfUIElement);
                _buildContent = null;
            }

            _buildContent = _implementation!.Build();

            if (_buildContent != null)
            {
                System.Windows.UIElement wpfUIElement = _buildContent.ToWpfUIElement();
                AddVisualChild(wpfUIElement);
                AddLogicalChild(wpfUIElement);
            }
#endif
        }
    }
}
