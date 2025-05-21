// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using System.Collections.Generic;
using UniversalUI.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly DependencyProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(IEnumerable<ITransform>), typeof(TransformGroup), null);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
    }
}
