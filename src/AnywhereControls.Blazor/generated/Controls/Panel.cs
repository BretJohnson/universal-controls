// This file is generated from IPanel.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.Blazor.Controls
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
        
        public override int VisualChildrenCount => _children.Count;
        
        public override IUIElement GetVisualChild(int index) => _children[index];
        
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
        
            // Use a CascadingValue to tell the children about their parent, so they add
            // themselves to the Children list
            RenderFragment ? childContent = ChildContent;
            if (childContent != null)
            {
                builder.OpenComponent<CascadingValue<IList?>>(11);
                builder.AddAttribute(12, "Value", Children);
                builder.AddAttribute(13, "Name", "ParentingInfo");
        
                builder.AddAttribute(14, "ChildContent", (RenderFragment)((builder2) => {
                    builder2.AddContent(15, childContent); 
                }));
                builder.CloseComponent();
            }
        }
    }
}
