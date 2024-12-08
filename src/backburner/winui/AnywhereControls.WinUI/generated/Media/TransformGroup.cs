// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using System.Collections.Generic;
using AnywhereUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly DependencyProperty ChildrenProperty = PropertyUtils.Register(nameof(Children), typeof(IEnumerable<ITransform>), typeof(TransformGroup), null);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
    }
}
