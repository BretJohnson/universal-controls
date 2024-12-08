using System;
using AnywhereUI.Controls;
using CommonUI;

namespace AnywhereControls.Blazor.NativeVisualFramework
{
    public partial class StandardControl : UIElement, IAnywhereControl, IAnywhereControlEnvironmentPeer
    {
        private AnywhereControls.Controls.AnywhereControl? _implementation;
        private IUIElement? _buildContent;
        private bool _invalid = true;

        public StandardControl()
        {
            if (!HostEnvironment.IsInitialized)
                BlazorHostFramework.Init(new BlazorNativeVisualFramework());
        }

        protected void InitImplementation(AnywhereControls.Controls.AnywhereControl implementation)
        {
            _implementation = implementation;
        }

        IUIElement? IAnywhereControlEnvironmentPeer.BuildContent => _buildContent;

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
