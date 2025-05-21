// This file is generated from IPanel.cs. Update the source file to change its contents.

using UniversalUI.Controls;
using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf.Controls
{
    [System.Windows.Markup.ContentProperty("Children")]
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly DependencyProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(UIElementCollection<System.Windows.FrameworkElement,UniversalUI.IUIElement>), typeof(Panel), null);

        private UIElementCollection<System.Windows.FrameworkElement,UniversalUI.IUIElement> _children;

        public Panel()
        {
            _children = new UIElementCollection<System.Windows.FrameworkElement,UniversalUI.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        public UIElementCollection<System.Windows.FrameworkElement,UniversalUI.IUIElement> Children => _children;
        IUICollection<IUIElement> IPanel.Children => Children.ToAnywhereControlsUIElementCollection();
        
        protected override int VisualChildrenCount => _children.Count;
        
        protected override System.Windows.Media.Visual GetVisualChild(int index) => (System.Windows.Media.Visual) _children[index];
    }
}
