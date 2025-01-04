// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using System.Collections.Generic;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly Avalonia.StyledProperty<IEnumerable<ITransform>> ChildrenProperty = AvaloniaProperty.Register<TransformGroup, IEnumerable<ITransform>>(nameof(Children), null);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
    }
}
