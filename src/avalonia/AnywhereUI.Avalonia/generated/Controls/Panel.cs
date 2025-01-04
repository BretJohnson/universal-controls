// This file is generated from IPanel.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Controls;
using Avalonia.Metadata;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Controls
{
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly Avalonia.StyledProperty<UIElementCollection<Avalonia.Controls.Control,AnywhereUI.IUIElement>> ChildrenProperty = AvaloniaProperty.Register<Panel, UIElementCollection<Avalonia.Controls.Control,AnywhereUI.IUIElement>>(nameof(Children), null);
        
        private UIElementCollection<Avalonia.Controls.Control,AnywhereUI.IUIElement> _children;
        
        public Panel()
        {
            _children = new UIElementCollection<Avalonia.Controls.Control,AnywhereUI.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        [Content] public UIElementCollection<Avalonia.Controls.Control,AnywhereUI.IUIElement> Children => _children;
        IUICollection<IUIElement> IPanel.Children => Children.ToAnywhereControlsUIElementCollection();
        
        #if LATER
        protected override int VisualChildrenCount => _children.Count;
        
        protected override System.Windows.Media.Visual GetVisualChild(int index) => (System.Windows.Media.Visual) _children[index];
        #endif
    }
}
