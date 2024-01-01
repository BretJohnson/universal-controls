// This file is generated from IPanel.cs. Update the source file to change its contents.

using AnywhereControls.Controls;
using DependencyProperty = System.Windows.DependencyProperty;

namespace AnywhereControls.Wpf.Controls
{
    [System.Windows.Markup.ContentProperty("Children")]
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly DependencyProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(UIElementCollection<System.Windows.FrameworkElement,AnywhereControls.IUIElement>), typeof(Panel), null);
        
        private UIElementCollection<System.Windows.FrameworkElement,AnywhereControls.IUIElement> _children;
        
        public Panel()
        {
            _children = new UIElementCollection<System.Windows.FrameworkElement,AnywhereControls.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        public UIElementCollection<System.Windows.FrameworkElement,AnywhereControls.IUIElement> Children => _children;
        IUICollection<IUIElement> IPanel.Children => Children.ToAnywhereControlsUIElementCollection();
        
        protected override int VisualChildrenCount => _children.Count;
        
        protected override System.Windows.Media.Visual GetVisualChild(int index) => (System.Windows.Media.Visual) _children[index];
    }
}
