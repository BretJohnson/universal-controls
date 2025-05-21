// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using System.Collections.Generic;
using UniversalUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace UniversalUI.Maui.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly BindableProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(IEnumerable<ITransform>), typeof(TransformGroup), null);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
    }
}
