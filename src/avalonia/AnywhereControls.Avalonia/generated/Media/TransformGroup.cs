// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using AnywhereControls;
using System.Collections.Generic;
using AnywhereControls.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly Avalonia.StyledProperty<IEnumerable<ITransform>> ChildrenProperty = AvaloniaProperty.Register<TransformGroup, IEnumerable<ITransform>>(nameof(Children), null);
        
        public IEnumerable<ITransform> Children => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
    }
}
