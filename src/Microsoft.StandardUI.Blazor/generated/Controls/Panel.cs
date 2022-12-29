// This file is generated from IPanel.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections;

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

        private RenderFragment? _childContent;
        [Parameter]
        public RenderFragment? ChildContent
        {
            get => _childContent;
            set
            {
                _childContent = value;
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            // Add children to the children list
            if (_childContent != null)
            {
                // Add the CascadingValue component
                builder.OpenComponent<CascadingValue<IList?>>(11);
                builder.AddAttribute(12, "Value", Children);
                builder.AddAttribute(13, "Name", "ParentingInfo");

                builder.AddAttribute(14, "ChildContent", (RenderFragment)((builder2) => {
                    builder2.AddContent(15, ChildContent);
                }));
                builder.CloseComponent();
            }
        }
    }
}
