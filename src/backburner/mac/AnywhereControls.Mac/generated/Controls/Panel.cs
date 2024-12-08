// This file is generated from IPanel.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly UIProperty ChildrenProperty = new UIProperty(nameof(Children), null, readOnly:true);
        
        private UIElementCollection<AnywhereControls.IUIElement> _children;
        
        public Panel()
        {
            _children = new UIElementCollection<AnywhereControls.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        public IUICollection<IUIElement> Children => _children.ToStandardUIElementCollection();
    }
}
