// This file is generated from IPanel.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections;
using AnywhereUI.Controls;

namespace AnywhereControls.Blazor.Controls
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
