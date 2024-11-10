// This file is generated from IPanel.cs. Update the source file to change its contents.

namespace AnywhereControls.Controls
{
    public static class PanelExtensions
    {
        public static T Children<T>(this T panel, params IUIElement[] value) where T : IPanel
        {
            panel.Children.Set(value);
            return panel;
        }
    }
}
