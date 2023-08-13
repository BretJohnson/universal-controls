// This file is generated from IPanel.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.WinForms.Controls
{
    public class Panel : BuiltInUIElement, IPanel
    {
        public static readonly UIProperty ChildrenProperty = new UIProperty(nameof(Children), null, readOnly:true);
        
        private UIElementCollection<Microsoft.StandardUI.IUIElement> _children;
        
        public Panel()
        {
            _children = new UIElementCollection<Microsoft.StandardUI.IUIElement>(this);
            SetValue(ChildrenProperty, _children);
        }
        
        public IUICollection<IUIElement> Children => _children.ToStandardUIElementCollection();
    }
}
