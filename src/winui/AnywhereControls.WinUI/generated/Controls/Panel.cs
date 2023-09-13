// This file is generated from IPanel.cs. Update the source file to change its contents.

using Microsoft.UI.Xaml.Markup;
using AnywhereControls.Controls;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Controls
{
    [ContentProperty(Name = "Children")]
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly DependencyProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(UIElementCollection<Microsoft.UI.Xaml.FrameworkElement,AnywhereControls.IUIElement>), typeof(Panel), null);
        
        private UIElementCollection<Microsoft.UI.Xaml.FrameworkElement,AnywhereControls.IUIElement> _children;
        
        public Panel()
        {
            _children = new UIElementCollection<Microsoft.UI.Xaml.FrameworkElement,AnywhereControls.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        public UIElementCollection<Microsoft.UI.Xaml.FrameworkElement,AnywhereControls.IUIElement> Children => _children;
        IUICollection<IUIElement> IPanel.Children => Children.ToStandardUIElementCollection();
    }
}
