// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using System.Collections.Generic;
using AnywhereUI.Media;

namespace AnywhereControls.Mac.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly UIProperty ChildrenProperty = new UIProperty(nameof(Children), null, readOnly:true);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetNonNullValue(ChildrenProperty);
    }
}
